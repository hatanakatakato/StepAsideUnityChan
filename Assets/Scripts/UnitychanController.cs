using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanController : MonoBehaviour
{
    //Animatorを宣言
    private Animator myAnimator;
    //Rigidbodyを宣言
    private Rigidbody myRigidbody;
    //前移動速度
    private float velocityZ = 16.0f;
    //横移動速度
    private float velocityX = 10f;
    //上移動速度
    private float velocityY = 10f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //動きを減速させる係数
    private float coefficient = 0.99f;
    //ゲーム終了の判定
    private bool isEnd = false;
    //GemeResultTextを宣言
    private GameObject gameResultText;
    //ScoreTextを宣言
    private GameObject scoreText;
    //得点
    private int score = 0;
    //左ボタン押したか
    private bool isLButtonDown = false;
    //右ボタン押下したか
    private bool isRButtonDown = false;
    //ジャンプボタン押したか
    private bool isJButtonDown = false;


    void Start()
    {
        //このGameObjectのAnimatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
        //このGameObjectのRigidbodyを取得
        this.myRigidbody = GetComponent<Rigidbody>();
        //同じシーン内のGameResultTextを取得
        this.gameResultText = GameObject.Find("GameResultText");
        //同じシーン内のScoreTextを取得
        this.scoreText = GameObject.Find("ScoreText");


        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1.0f);

    }

    void Update()
    {
        //ゲーム終了なら動きを遅くする
        if (this.isEnd)
        {
            //0.99fをかけ続けることで減速させている
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //横方向の入力による速度
        float inputVelocityX = 0;
        //上方向の入力による速度
        float inputVelocityY = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if ((Input.GetKey(KeyCode.LeftArrow) ||this.isLButtonDown)&& -this.movableRange < this.transform.position.x)
        {
            //左方向への速度を代入
            inputVelocityX = -this.velocityX;
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown)&& this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入
            inputVelocityX = this.velocityX;
        }

        //高さが0.5f以下の時にスペースキーが押されたらジャンプ
        if ((Input.GetKeyDown(KeyCode.Space) || this.isJButtonDown)&& this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jumpステートの場合はJumpにfalseをセットする
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

        //Unityちゃんに速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }


    private void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            this.gameResultText.GetComponent<Text>().text = "GAME OVER";
        }

        //ゴール地点に到達した場合
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.gameResultText.GetComponent<Text>().text = "CLEAR!!";
        }

        //コインに接触した場合
        if (other.gameObject.tag == "CoinTag")
        {
            //スコア加算
            this.score += 10;
            //スコアテキスト再描画
            this.scoreText.GetComponent<Text>().text = $"Score {this.score}pt";
            //パーティクルを再生（追加）
            GetComponent<ParticleSystem>().Play();
            //破壊する
            Destroy(other.gameObject);
            
        }
    }

    //ジャンプボタンを押した場合の処理
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }

    //ジャンプボタンを離した場合の処理
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}

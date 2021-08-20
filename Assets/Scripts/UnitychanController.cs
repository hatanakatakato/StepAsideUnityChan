using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        //このGameObjectのAnimatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
        //このGameObjectのRigidbodyを取得
        this.myRigidbody = GetComponent<Rigidbody>();


        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1.0f);

    }

    void Update()
    {
        //横方向の入力による速度
        float inputVelocityX = 0;
        //上方向の入力による速度
        float inputVelocityY = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if (Input.GetKey(KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //左方向への速度を代入
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入
            inputVelocityX = this.velocityX;
        }

        //高さが0.5f以下の時にスペースキーが押されたらジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
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
}

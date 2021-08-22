using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //Prefabはpublicで注入する
    public GameObject carPrefab;
    //Prefabはpublicで注入する
    public GameObject coinPrefab;
    //Prefabはpublicで注入する
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //unitychan(gameobject)取得
    private GameObject unitychan;
    //アイテム出現z座標
    private float nextItemAppearPosZ = 60;

    void Start()
    {
        //同じシーン内のgameobj取得
        this.unitychan = GameObject.Find("unitychan");

        
    }

    void Update()
    {

        //z軸60前方にアイテムを出現させ続ける(15区切りで）(goalまで）
        if (this.nextItemAppearPosZ - this.unitychan.GetComponent<Transform>().transform.position.z < 60 && this.nextItemAppearPosZ < this.goalPos)
        {
            
            //coneを出すかその他かランダムに決める
            int num = Random.Range(1, 11);

            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                //coneインスタンスはforが回る度に毎回新しく作られている
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    //conePrefabのインスタンスを生成
                    GameObject cone = Instantiate(conePrefab);
                    //インスタンスを配置
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.nextItemAppearPosZ);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //cone以外でアイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //coinPrefabをインスタンス化
                        GameObject coin = Instantiate(coinPrefab);
                        //インスタンスを配置
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.nextItemAppearPosZ + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //carPrefabをインスタンス化
                        GameObject car = Instantiate(carPrefab);
                        //インスタンスを配置
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.nextItemAppearPosZ + offsetZ);
                    }
                }
            }
           
            //次のアイテム出現位置を決定
            this.nextItemAppearPosZ += 15;

        }
    }
}

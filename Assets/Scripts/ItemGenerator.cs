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

    void Start()
    {
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムにする
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
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //coinPrefabをインスタンス化
                        GameObject coin = Instantiate(coinPrefab);
                        //インスタンスを配置
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //carPrefabをインスタンス化
                        GameObject car = Instantiate(carPrefab);
                        //インスタンスを配置
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }

    void Update()
    {

    }
}

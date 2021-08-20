using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    //unitychanのGameObjectを宣言
    private GameObject unitychan;
    //unitychanとカメラとの距離
    private float difference;

    void Start()
    {
        //unitychanを取得(参照型）
        this.unitychan = GameObject.Find("unitychan");
        //unitychanとカメラとの距離(値型)
        this.difference = this.unitychan.transform.position.z - this.transform.position.z;
        
    }

    void Update()
    {
        this.transform.position = new Vector3(
            0,
            this.transform.position.y,
            this.unitychan.transform.position.z - this.difference
            );
    }
}

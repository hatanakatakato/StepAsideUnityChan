using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrafabController : MonoBehaviour
{

    private GameObject unitychan;
    private float distance = 10.0f;

    private void Start()
    {
        //これprefabは生成されてるから使えるのか？→使えてたよ
        this.unitychan = GameObject.Find("unitychan");
    }


    void Update()
    {
        //Prafabとunitychanがdistance離れたらprefabを消す
        if(this.unitychan.GetComponent<Transform>().transform.position.z - this.transform.position.z > this.distance)
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    void Start()
    {
        //まずランダムな位置に回転させる
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        //3ずつ回転させる
        this.transform.Rotate(0, 3, 0);
    }
}

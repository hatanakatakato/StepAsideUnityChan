using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanController : MonoBehaviour
{
    //Animatorを宣言
    private Animator myAnimator;
    //Rigidbodyを宣言
    private Rigidbody myRigidbody;
    //移動速度
    private float velosityZ = 16.0f;

    void Start()
    {
        //このGameObjectのAnimatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
        //このGameObjectのRigidbodyを取得
        this.myRigidbody = GetComponent<Rigidbody>();


        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //unitychanを速度を与えて移動させる
        this.myRigidbody.velocity = new Vector3(0, 0, this.velosityZ);
        
    }
}

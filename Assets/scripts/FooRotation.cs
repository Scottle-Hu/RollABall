using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制食物小球旋转
public class FooRotation : MonoBehaviour {

    //每秒旋转的度数
    public int angle;

	// Use this for initialization
	void Start () {
        angle = 180;

    }
	
	// Update is called once per frame
	void Update () {
        //每秒旋转angle度数
        this.transform.Rotate(new Vector3(0, 1, 0), angle * Time.deltaTime);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//控制小球的转动
public class BallScript : MonoBehaviour {

    //相机跟随
    public Camera camera;

    //施加力的大小
    public int force = 5;

    //显示分数的GUI
    public Text scoreText;

    //显示胜利的GUI
    public GameObject winObject;

    //显示失败的GUI
    public GameObject failObject;

    //刚体运动
    private Rigidbody rigidbody;

    private Vector3 ball2Camera;

    //当前所得分数
    private int score;

    //标识是否已经输了
    private bool hasFailed = false;

	// Use this for initialization
	void Start () {
        //初始化刚体
        rigidbody = GetComponent<Rigidbody>();
        //初始化摄像机与小球之间的向量
        ball2Camera = camera.transform.position - this.transform.position;
        //初始化分数为0
        score = 0;

    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");  //键盘水平选择
        float v = Input.GetAxis("Vertical");  //键盘上下选择
        Debug.Log("h="+h+", v="+v);
        //对小球的物理刚体施加力
        if (h > 0)
        {
            rigidbody.AddForce(new Vector3(1, 0, 0) * force);
        }
        if (h < 0)
        {
            rigidbody.AddForce(new Vector3(-1, 0, 0) * force);
        }
        if (v > 0)
        {
            rigidbody.AddForce(new Vector3(0, 0, 1) * force);

        }
        if (v < 0)
        {
            rigidbody.AddForce(new Vector3(0, 0, -1) * force);

        }

        //重置摄像机的位置，以跟随小球
        camera.transform.position = this.transform.position + ball2Camera;
    }

    //碰撞检测消除小球
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.collider.tag;  //获取碰撞物体的tag
        //if (tag == "food")  //和食物碰撞
        //{
        //    score++;  //分数+1
        //    Destroy(collision.collider.gameObject);  //销毁食物小方块
        //    //判断是否赢了
        //    if (score == 12)
        //    {
        //        winObject.SetActive(true);  //显示胜利字样
        //    }
        //    scoreText.text = "当前得分：" + score;  //设置得分GUI
        //}

        //如果撞到围栏则输了
        if (tag == "Finish")
        {
            hasFailed = true;
            failObject.SetActive(true);
        }
    }

    //出发监测消除小球，不会影响ball的运动
    private void OnTriggerEnter(Collider other)
    {
        if (hasFailed)
        {
            return;  //已经输了不作处理
        } 
        string tag = other.tag;
        if (tag == "food")  //和食物碰撞
        {
            score++;  //分数+1
            Destroy(other.gameObject);  //销毁食物小方块
            //判断是否赢了
            if (score == 12)
            {
                winObject.SetActive(true);  //显示胜利字样
            }
            scoreText.text = "当前得分：" + score;  //设置得分GUI
        }

    }

}

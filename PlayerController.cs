using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;  //定义刚体组件类型的变量
    public bool isGrounded = false;
    public int Initializationiscomplete = 0;
    // Start is called before the first frame update
    void Start() // 初始化代码
    {
        playerRb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()  // 每帧执行一次
    {
        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            playerRb.velocity = new Vector2(0, 13f);

        }
    }

    void OnCollisionEnter2D(Collision2D other) // 物体发生2D 碰撞时自动调用
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = true;
            if (Initializationiscomplete == 0) {
                Initializationiscomplete++;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) // 物体离开碰撞时自动调用
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }

}
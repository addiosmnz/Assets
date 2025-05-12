using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 定义一个变量来引用玩家对象
    public Transform player;
    public Transform ground;  // 用来引用地板
    // 可选：设定摄像机相对于玩家的Y轴偏移（稍微高一点或低一点）
    public float yOffset = 4.9f;
    public float initial = 0;
    public float smoothSpeed = 0.125f; // 平滑跟随的速度
    private Vector3 offset;    // 摄像机和玩家之间的偏移
    public PlayerController playerController;  // 用来引用 PlayerController

    void Start()
    {
        // 获取玩家的位置（我们在检查器里将它关联到玩家对象）
       player = GameObject.Find("Player").transform;
       ground = GameObject.Find("Ground").transform;  // 获取地板的 Transform
       playerController = GameObject.Find("Player").GetComponent<PlayerController>();// 获取 PlayerController 组件
    }

    void Update()
    {
        if (playerController.Initializationiscomplete == 1)//物体第一次落地完毕！
        {  
            
            playerController.Initializationiscomplete++;

        }
        if (playerController.Initializationiscomplete > 1)
        {

            if (player.position.y > 8f)
            {
                //Debug.Log("进了...............");
                offset = transform.position - player.position; // 计算摄像机和玩家之间的偏移
                offset.y = 1; // 设置摄像机和玩家之间的偏移为1
                Vector3 desiredPosition = transform.position;// 计算摄像机的目标位置：玩家位置 + 偏移
                desiredPosition.y = 4.9f + player.position.y - 8f;// 计算摄像机的目标位置：4.9+玩家超越8后的位置 - 8
                Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);// 使摄像机平滑跟随玩家  Vector3.Lerp(a, b, t) 是 Unity 的一个函数，用来平滑地从 a 位置过渡到 b 位置，t 是一个平滑的插值参数，通常在 0 到 1 之间。
                transform.position = smoothPosition; // 设置摄像机的新位置

            }
            
                
        
            
            
           



        }
       



    }
}

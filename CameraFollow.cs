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
    public float smoothSpeed = 0.02f; // 平滑跟随的速度
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

            // 计算当前摄像机位置与玩家位置的偏移量
            offset = transform.position - player.position;
            // 将偏移量的 y 轴值固定为 1，保证摄像机和玩家在 y 轴上始终保持一定的相对距离
            offset.y = 1;
            // 创建一个新的向量 desiredPosition，初始值为当前摄像机的位置
            Vector3 desiredPosition = transform.position;
            // 计算期望的摄像机 y 轴位置
            // yOffset 是摄像机的初始 y 轴偏移量（通常为 4.9）
            // player.position.y - 8f 表示玩家位置超出 y 轴 8 的部分
            // 这样计算可以让摄像机随着玩家上升和下落而移动
            desiredPosition.y = yOffset + player.position.y - 8f;


            // Mathf.Max 函数用于返回两个值中的较大值
            // 这里保证了 desiredPosition.y 不会小于 yOffset（即 4.9）
            // 从而避免摄像机位置过低
            desiredPosition.y = Mathf.Max(desiredPosition.y, yOffset);


            // Vector3.Lerp 是 Unity 中的线性插值函数
            // 它会在当前摄像机位置 transform.position 和期望位置 desiredPosition 之间进行插值
            // smoothSpeed 是插值的速度，取值范围通常在 0 到 1 之间
            // 该函数会根据 smoothSpeed 的值逐渐将摄像机从当前位置移动到期望位置
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 将摄像机的位置更新为平滑插值后的位置
            // 这样摄像机就会平滑地跟随玩家移动
            transform.position = smoothPosition;





        }
       



    }
}

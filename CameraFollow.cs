using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform ground;
    public float yOffset = 4.9f;
    public float smoothSpeed = 0.005f;
    private Vector3 offset;
    public PlayerController playerController;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        ground = GameObject.Find("Ground").transform;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (playerController.Initializationiscomplete == 1)
        {
            playerController.Initializationiscomplete++;
        }
        if (playerController.Initializationiscomplete > 1)
        {
            // 计算期望的摄像机位置
            float actualSmoothSpeed = smoothSpeed * Time.deltaTime;
            offset = transform.position - player.position;
            offset.y = 1;
            Vector3 desiredPosition = transform.position;
            desiredPosition.y = yOffset + player.position.y - 8f;

            // 确保摄像机不会低于初始值 4.9
            desiredPosition.y = Mathf.Max(desiredPosition.y, yOffset);

            // 使用平滑插值更新摄像机位置
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothPosition;
        }
    }
}
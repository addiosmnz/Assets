using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // ����һ��������������Ҷ���
    public Transform player;
    public Transform ground;  // �������õذ�
    // ��ѡ���趨������������ҵ�Y��ƫ�ƣ���΢��һ����һ�㣩
    public float yOffset = 4.9f;
    public float initial = 0;
    public float smoothSpeed = 0.125f; // ƽ��������ٶ�
    private Vector3 offset;    // ����������֮���ƫ��
    public PlayerController playerController;  // �������� PlayerController

    void Start()
    {
        // ��ȡ��ҵ�λ�ã������ڼ�����ｫ����������Ҷ���
       player = GameObject.Find("Player").transform;
       ground = GameObject.Find("Ground").transform;  // ��ȡ�ذ�� Transform
       playerController = GameObject.Find("Player").GetComponent<PlayerController>();// ��ȡ PlayerController ���
    }

    void Update()
    {
        if (playerController.Initializationiscomplete == 1)//�����һ�������ϣ�
        {  
            
            playerController.Initializationiscomplete++;

        }
        if (playerController.Initializationiscomplete > 1)
        {

            if (player.position.y > 8f)
            {
                //Debug.Log("����...............");
                offset = transform.position - player.position; // ��������������֮���ƫ��
                offset.y = 1; // ��������������֮���ƫ��Ϊ1
                Vector3 desiredPosition = transform.position;// �����������Ŀ��λ�ã����λ�� + ƫ��
                desiredPosition.y = 4.9f + player.position.y - 8f;// �����������Ŀ��λ�ã�4.9+��ҳ�Խ8���λ�� - 8
                Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);// ʹ�����ƽ���������  Vector3.Lerp(a, b, t) �� Unity ��һ������������ƽ���ش� a λ�ù��ɵ� b λ�ã�t ��һ��ƽ���Ĳ�ֵ������ͨ���� 0 �� 1 ֮�䡣
                transform.position = smoothPosition; // �������������λ��

            }
            
                
        
            
            
           



        }
       



    }
}

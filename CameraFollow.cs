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
    public float smoothSpeed = 0.02f; // ƽ��������ٶ�
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

            // ���㵱ǰ�����λ�������λ�õ�ƫ����
            offset = transform.position - player.position;
            // ��ƫ������ y ��ֵ�̶�Ϊ 1����֤������������ y ����ʼ�ձ���һ������Ծ���
            offset.y = 1;
            // ����һ���µ����� desiredPosition����ʼֵΪ��ǰ�������λ��
            Vector3 desiredPosition = transform.position;
            // ��������������� y ��λ��
            // yOffset ��������ĳ�ʼ y ��ƫ������ͨ��Ϊ 4.9��
            // player.position.y - 8f ��ʾ���λ�ó��� y �� 8 �Ĳ���
            // �������������������������������������ƶ�
            desiredPosition.y = yOffset + player.position.y - 8f;


            // Mathf.Max �������ڷ�������ֵ�еĽϴ�ֵ
            // ���ﱣ֤�� desiredPosition.y ����С�� yOffset���� 4.9��
            // �Ӷ����������λ�ù���
            desiredPosition.y = Mathf.Max(desiredPosition.y, yOffset);


            // Vector3.Lerp �� Unity �е����Բ�ֵ����
            // �����ڵ�ǰ�����λ�� transform.position ������λ�� desiredPosition ֮����в�ֵ
            // smoothSpeed �ǲ�ֵ���ٶȣ�ȡֵ��Χͨ���� 0 �� 1 ֮��
            // �ú�������� smoothSpeed ��ֵ�𽥽�������ӵ�ǰλ���ƶ�������λ��
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // ���������λ�ø���Ϊƽ����ֵ���λ��
            // ����������ͻ�ƽ���ظ�������ƶ�
            transform.position = smoothPosition;





        }
       



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;  //�������������͵ı���
    public bool isGrounded = false;
    public int Initializationiscomplete = 0;
    // Start is called before the first frame update
    void Start() // ��ʼ������
    {
        playerRb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()  // ÿִ֡��һ��
    {
        if (Input.GetMouseButtonDown(0) && isGrounded == true)
        {
            playerRb.velocity = new Vector2(0, 13f);

        }
    }

    void OnCollisionEnter2D(Collision2D other) // ���巢��2D ��ײʱ�Զ�����
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = true;
            if (Initializationiscomplete == 0) {
                Initializationiscomplete++;
            }
        }
    }

    void OnCollisionExit2D(Collision2D other) // �����뿪��ײʱ�Զ�����
    {
        if (other.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }

}
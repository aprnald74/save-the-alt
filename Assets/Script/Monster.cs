using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    // Ÿ�� �÷��̾�
    public Transform target;

    // ���� �����̴� �ӵ�
    private float speed;

    // ���� ����ִ��� ���� true�� ��� �ִ°�
    private bool isLive;

    private float angle;

    void Start()
    {
        isLive = true;
        speed = 1;
    }

    void Update()
    {

        // ����ī�޶� �ִ� Line_Maker��� ��ũ��Ʈ�� �ִ� cnt�� 1�̶� ��� ������ ������
        if (GameObject.Find("Main Camera").GetComponent<Line_Maker>().cnt == 1 && isLive)
        {

            // Ÿ�ٿ� ��ġ�� �˾ƿ�
            Vector3 dir = target.position - transform.position;

            // Ÿ�� �������� �ٰ���
            transform.position += dir * speed * Time.deltaTime;

            // Ÿ�� �������� ȸ����
            //angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    // 1�� : ó�� �ε�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("�±�"))
        //{
                        
        //}
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    void Update()
    {

        // �ڽ��� ��ġ���� ��� �޴´�
        Vector2 currentPosition = transform.position;

        //������Ʈ�� Y�� ���� -5�̻� �������� ����
        if (currentPosition.y <= -5)
        {
            // ������Ʈ�� (0,4) ��ǥ�� �̵���Ŵ
            transform.position = new Vector2(0, 4);

            
        }
    }

    // 1�� : ó�� �ε�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�������� ������
        if (collision.collider.CompareTag("Monster"))
        {
            Debug.Log("�������� ����");
        }
        if (collision.collider.CompareTag("Spike"))
        {
            Debug.Log("���ÿ� ���� ����");
        }
    }

    //if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
}

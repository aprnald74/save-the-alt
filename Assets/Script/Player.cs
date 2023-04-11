using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    // �ڽ��� ��ġ���� �޴ٰ�
    // y���� -5���Ϸ� �������� 0, 4�� �̵�
    void Update() {
        Vector2 currentPosition = transform.position;
        if (currentPosition.y <= -5) {
            transform.position = new Vector2(0, 4);
        }
    }

    // ���� ������Ʈ�� Monster�̰ų� Spike�� ������ �˷���
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Monster")) {
            Debug.Log("�������� ����");
        }
        if (collision.collider.CompareTag("Spike")) {
            Debug.Log("���ÿ� ���� ����");
        }
    }

    //if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
}

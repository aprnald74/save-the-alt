using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineFind : MonoBehaviour
{
    //���콺 ���츦 �����ϱ� ���� ����
    Vector3 mPosition;
    
    //������Ʈ ȸ��
    private float rotateDegree;

    //������Ʈ, ���콺 �Ÿ� ���ϱ� ���� ����
    private float distance;


    // ���콺 ��ǥ���� ������Ʈ �ø���, ���콺 �ٶ󺸰� �ϴ� �ڵ�
    void Update() {

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 oPosition = transform.position;
        Vector3 target = mPosition - transform.position;

        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);
    }

    // Ground, Player, Monster, Spike�� ���̰� ������ objectFind false�� �ٲ�
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Spike") 
        {
            Debug.Log("�浹��");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
        }
    }

    // Ʈ���ſ��� ����� objectFind true�� �ٲٰ�, �� ������Ʈ ������
    void OnTriggerExit2D(Collider2D col) {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        Destroy(gameObject);
    }

    ////������Ʈ�� collider�� ������
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    // ���� ������Ʈ �±װ� Ground�� Player�� Monster�� Spike�̸�
    //    if (col.gameObject.tag == "Ground" |
    //       col.gameObject.tag == "Player" |
    //       col.gameObject.tag == "Monster" |
    //       col.gameObject.tag == "Spike")
    //    {
    //        Debug.Log("�ߵ�");
    //        //���콺 ��ġ���� ������Ʈ �̵�
    //        transform.position = new Vector2(mPosition.x, mPosition.y);
    //    }
    //    else
    //    {
    //        Debug.Log("�浹����");
    //        //���ǹ��� ���� �±׿� ������ 0,0���� �̵�
    //        transform.position = new Vector2(0, 0);
    //    }
    //}
}

// gameObject.SetActive(false);
//if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
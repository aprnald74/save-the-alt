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

    void Start()
    {
        
    }

    void Update()
    {

        // ���콺 ��ǥ ����
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ���� ������Ʈ ��ǥ ����
        Vector3 oPosition = transform.position; 
        
        // �� �� �Ÿ� ���ϴ� ���� �̿��ؼ� ������Ʈ �ø��� ����
        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        // ���콺�� ��ǥ���� ������Ʈ ��ġ�� ������ target�� ����
        Vector3 target = mPosition - transform.position;

        // ��ŭ ȸ������ ����
        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        // ������ ������ z���� �������� ���� ������Ʈ�� ȸ����ŵ�ϴ�.
        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);
    }

    //������Ʈ�� collider�� ������ 1���� ����
    void OnTriggerEnter2D(Collider2D col)
    {
        // ���� ������Ʈ �±װ� Ground�� Player�� Monster�� Spike�̸�
        if(col.gameObject.tag == "Ground" | 
           col.gameObject.tag == "Player" | 
           col.gameObject.tag == "Monster" | 
           col.gameObject.tag == "Spike")
        {
            //���콺 ��ġ���� ������Ʈ �̵�
            transform.position = new Vector2(mPosition.x, mPosition.y);
            //Debug.Log("�浹");
        }
        else
        {
            //���ǹ��� ���� �±׿� ������ 0,0���� �̵�
            transform.position = new Vector2(0, 0);
            //Debug.Log("�浹X");
        }
    }
}

// gameObject.SetActive(false);
//if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
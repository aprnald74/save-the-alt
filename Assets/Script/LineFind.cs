using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineFind : MonoBehaviour
{

    
    private float rotateDegree;

    private float distance;

    void Start()
    {
        //col.isTrigger = false;
    }

    void Update()
    {


        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ǥ ����
        Vector3 oPosition = transform.position; // ���� ������Ʈ ��ǥ ����
        
        // �� �� �Ÿ� ���ϴ� ���� �̿��ؼ� ������Ʈ �ø��� ����
        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        // ���콺�� ��ǥ�� target�� ����
        Vector3 target = mPosition - transform.position;

        // ��ŭ ȸ������ ����
        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        // ������ ������ z���� �������� ���� ������Ʈ�� ȸ����ŵ�ϴ�.
        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            Debug.Log("�浹");
        }
        else
        {
            Debug.Log("�浹X");
        }
    }
}

// gameObject.SetActive(false);
//if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
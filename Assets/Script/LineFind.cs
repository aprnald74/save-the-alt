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

    public CircleCollider2D mouse;

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

    // Ʈ���ſ��� ����� objectFind true�� �ٲٰ�, �� ������Ʈ ������
    void OnTriggerExit2D(Collider2D col) {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        GameObject.Find("Mouse").GetComponent<Mouse>().isna = true;
        mouse.enabled = true;
        Destroy(gameObject);
    }
}

// gameObject.SetActive(false);
//if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
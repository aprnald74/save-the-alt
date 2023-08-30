using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineFind : MonoBehaviour
{
    // ���콺 ��ǥ�� �����ϱ� ���� ����
    Vector3 mPosition;
    
    // ������Ʈ ȸ���� ���� ����
    float rotateDegree;

    // ������Ʈ, ���콺 �Ÿ� ���ϱ� ���� ����
    float distance;

    // ���� ������ Ȱ���Ͽ� LineFinde������Ʈ�� ���콺 ��ġ�� ���� �ٴϸ鼭 �����̰� ��
    void Update() 
    {

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 oPosition = transform.position;
        Vector3 target = mPosition - transform.position;

        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);

    }

    // ������Ʈ�� �浹���� ����� �ٽ� �׸��� �ְ� ����� Mouse collider�� Ȱ��ȭ �����ְ� �� ������Ʈ�� �����Ѵ�
    void OnTriggerExit2D(Collider2D col)
    {
        GameObject.Find("GameManager").GetComponent<LineMaker>().cheackTwo = true;
        GameObject.Find("Mouse").GetComponent<Mouse>().CMP = true;

        Destroy(gameObject);
    }
}
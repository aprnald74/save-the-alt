using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Line_Finder ������Ʈ�� ������ ����
    public GameObject LineFInder;

    // Mouse ��ġ�� �����ϱ� ���� �ִ� ����
    Vector3 mPosition;

    public bool isna;

    CircleCollider2D circleCollider;

    void Start()
    {
        isna = true;
        circleCollider = GetComponent <CircleCollider2D>();
    }

    // ���콺 ��ġ�� ������Ʈ ��� �̵�
    void Update() {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    // ���� ������Ʈ �±װ� Ground�� Player�� Monster�� Spike�̸�
    // ������Ʈ ��ġ�� Line_Finder������Ʈ ������
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Spike"  && isna) 
        {
            Debug.Log("�浹");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
            circleCollider.enabled = false; //������Ʈ ��Ȱ��ȭ
            isna = false;


            Instantiate(LineFInder, transform.position, transform.rotation);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Line_Finder������Ʈ ����
    GameObject LineFinder;

    // Mouse ��ġ�� �޾ƿ��� ���� ����
    Vector3 mPosition;

    // Mouse ������Ʈ collider�� �޾ƿ��� ���� ����
    CircleCollider2D circleCollider;

    // CMP�� true�� �� ������Ʈ�� collider�� ������ false�� collider�� ����
    public bool CMP;

    void Start()
    {
        GameSetting();
    }

    void GameSetting()
    {
        // ó���� colliderȰ��ȭ
        CMP = true;

        // �� ������Ʈ �ݸ��� ������
        circleCollider = gameObject.GetComponent<CircleCollider2D>();

        // ����ȭ�δ� ������ ã�ƿ�
        LineFinder = Resources.Load<GameObject>("Prefab/LineFinder");
    }

    // ���콺 ��ġ�� ������Ʈ ��� �̵�
    void FixedUpdate()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺�� ��� �޾ƿ���
        transform.position = new Vector2(mPosition.x, mPosition.y);      // �� ��ġ�� ��� ����ٴϰ� ����

        circleCollider.enabled = CMP; // CMP���� ���� colliderȰ��ȭ ��Ŵ
    }

    // ������Ʈ�� �浹������ collider�� ��� �ְ�, 
    // �浹 ������Ʈ�� Ground, Player, Monster, Trap�� Line_Finder ������Ʈ ����
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Trap" && CMP)  {
            GameObject.Find("GameManager").GetComponent<LineMaker>().cheackTwo = false; // ������Ʈ�� �浹�ϸ� ���׸��� �ϱ� ���� cheackTwo�� ��Ȱ��ȭ ��Ŵ

            CMP = false;
            circleCollider.enabled = col; // collider ��Ȱ��ȭ

            Instantiate(LineFinder, transform.position, transform.rotation); // ���� ��ġ�� Line_Finder������Ʈ ������
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject LineFInder;
    Vector3 mPosition;

    void Update()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    void OnTriggerStay2D(Collider2D col)
    {
            // ���� ������Ʈ �±װ� Ground�� Player�� Monster�� Spike�̸�
            if (col.gameObject.tag == "Ground" |
               col.gameObject.tag == "Player" |
               col.gameObject.tag == "Monster" |
               col.gameObject.tag == "Spike")
        {
            Debug.Log("�浹");
            Instantiate(LineFInder);
        }
    }

}

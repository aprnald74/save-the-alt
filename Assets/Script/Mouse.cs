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
            // 닿은 오브젝트 태그가 Ground나 Player나 Monster나 Spike이면
            if (col.gameObject.tag == "Ground" |
               col.gameObject.tag == "Player" |
               col.gameObject.tag == "Monster" |
               col.gameObject.tag == "Spike")
        {
            Debug.Log("충돌");
            Instantiate(LineFInder);
        }
    }

}

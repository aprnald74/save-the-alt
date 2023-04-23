using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Line_Finder 오브젝트를 복제를 위해
    public GameObject LineFInder;

    // Mouse 위치값 저장하기 위해 있는 변수
    Vector3 mPosition;

    public bool isna;

    CircleCollider2D circleCollider;

    void Start()
    {
        isna = true;
        circleCollider = GetComponent <CircleCollider2D>();
    }

    // 마우스 위치에 오브젝트 계속 이동
    void Update() {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mPosition.x, mPosition.y);
    }

    // 닿은 오브젝트 태그가 Ground나 Player나 Monster나 Spike이면
    // 오브젝트 위치에 Line_Finder오브젝트 생성함
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Spike"  && isna) 
        {
            Debug.Log("충돌");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
            circleCollider.enabled = false; //컴포넌트 비활성화
            isna = false;


            Instantiate(LineFInder, transform.position, transform.rotation);
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineFind : MonoBehaviour
{
    //마우스 좌펴를 저장하기 위한 변수
    Vector3 mPosition;
    
    //오브젝트 회전
    private float rotateDegree;

    //오브젝트, 마우스 거리 구하기 위한 변수
    private float distance;


    // 마우스 좌표까지 오브젝트 늘리고, 마우스 바라보게 하는 코드
    void Update() {

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 oPosition = transform.position;
        Vector3 target = mPosition - transform.position;

        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);
    }

    // Ground, Player, Monster, Spike에 닿이고 있으면 objectFind false로 바꿈
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Spike") 
        {
            Debug.Log("충돌중");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
        }
    }

    // 트리거에서 벗어나면 objectFind true로 바꾸고, 이 오브젝트 삭제함
    void OnTriggerExit2D(Collider2D col) {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        Destroy(gameObject);
    }

    ////오브젝트가 collider에 닿으면
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    // 닿은 오브젝트 태그가 Ground나 Player나 Monster나 Spike이면
    //    if (col.gameObject.tag == "Ground" |
    //       col.gameObject.tag == "Player" |
    //       col.gameObject.tag == "Monster" |
    //       col.gameObject.tag == "Spike")
    //    {
    //        Debug.Log("추돌");
    //        //마우스 위치값에 오브젝트 이동
    //        transform.position = new Vector2(mPosition.x, mPosition.y);
    //    }
    //    else
    //    {
    //        Debug.Log("충돌안함");
    //        //조건문에 없는 태그에 닿으면 0,0으로 이동
    //        transform.position = new Vector2(0, 0);
    //    }
    //}
}

// gameObject.SetActive(false);
//if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
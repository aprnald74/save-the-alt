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

    void Start()
    {
        
    }

    void Update()
    {

        // 마우스 좌표 저장
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 게임 오브젝트 좌표 저장
        Vector3 oPosition = transform.position; 
        
        // 두 점 거리 구하는 공식 이용해서 오브젝트 늘리고 줄임
        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        // 마우스의 좌표에서 오브젝트 위치를 뺀것을 target에 저장
        Vector3 target = mPosition - transform.position;

        // 얼만큼 회전할지 구함
        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        // 구해진 각도를 z축을 기준으로 게임 오브젝트를 회전시킵니다.
        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);
    }

    //오브젝트가 collider에 닿으면 1번만 실행
    void OnTriggerEnter2D(Collider2D col)
    {
        // 닿은 오브젝트 태그가 Ground나 Player나 Monster나 Spike이면
        if(col.gameObject.tag == "Ground" | 
           col.gameObject.tag == "Player" | 
           col.gameObject.tag == "Monster" | 
           col.gameObject.tag == "Spike")
        {
            //마우스 위치값에 오브젝트 이동
            transform.position = new Vector2(mPosition.x, mPosition.y);
            //Debug.Log("충돌");
        }
        else
        {
            //조건문에 없는 태그에 닿으면 0,0으로 이동
            transform.position = new Vector2(0, 0);
            //Debug.Log("충돌X");
        }
    }
}

// gameObject.SetActive(false);
//if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
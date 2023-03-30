using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineFind : MonoBehaviour
{

    private float dx;
    private float dy;
    private float rotateDegree;

    private float mx;
    private float mz;

    private float lx;
    private float lz;

    private float distance;

    void Start()
    {
        //transform.localScale = new Vector2(0, 0);
        //transform.position = new Vector2(0, 0);
    }

    void Update()
    {
        
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 저장
        Vector3 oPosition = transform.position; // 게임 오브젝트 좌표 저장
        
        // 두 점 거리 구하는 공식 이용해서 오브젝트 늘리고 줄임
        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        // 마우스의 좌표를 target에 저장
        Vector3 target = mPosition - transform.position;

        // 얼만큼 회전할지 구함
        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        // 구해진 각도를 z축을 기준으로 게임 오브젝트를 회전시킵니다.
        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);

    }
}

// gameObject.SetActive(false);
//if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
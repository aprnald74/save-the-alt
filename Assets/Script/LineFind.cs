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

    public CircleCollider2D mouse;

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

    // 트리거에서 벗어나면 objectFind true로 바꾸고, 이 오브젝트 삭제함
    void OnTriggerExit2D(Collider2D col) {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        GameObject.Find("Mouse").GetComponent<Mouse>().isna = true;
        mouse.enabled = true;
        Destroy(gameObject);
    }
}

// gameObject.SetActive(false);
//if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
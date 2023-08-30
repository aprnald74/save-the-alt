using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LineFind : MonoBehaviour
{
    // 마우스 좌표를 저장하기 위한 변수
    Vector3 mPosition;
    
    // 오브젝트 회전을 위한 변수
    float rotateDegree;

    // 오브젝트, 마우스 거리 구하기 위한 변수
    float distance;

    // 수학 공식을 활용하여 LineFinde오브젝트가 마우스 위치에 따라 다니면서 움직이게 함
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

    // 오브젝트랑 충돌에서 벗어나면 다시 그릴수 있게 만들고 Mouse collider를 활성화 시켜주고 이 오브젝트를 삭제한다
    void OnTriggerExit2D(Collider2D col)
    {
        GameObject.Find("GameManager").GetComponent<LineMaker>().cheackTwo = true;
        GameObject.Find("Mouse").GetComponent<Mouse>().CMP = true;

        Destroy(gameObject);
    }
}
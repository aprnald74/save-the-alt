using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Line_Finder오브젝트 저장
    GameObject LineFinder;

    // Mouse 위치값 받아오기 위한 변수
    Vector3 mPosition;

    // Mouse 오브젝트 collider를 받아오기 위한 변수
    CircleCollider2D circleCollider;

    // CMP가 true면 이 오브젝트에 collider이 켜지고 false면 collider이 꺼짐
    public bool CMP;

    void Start()
    {
        GameSetting();
    }

    void GameSetting()
    {
        // 처음은 collider활성화
        CMP = true;

        // 이 오브젝트 콜리더 가져옴
        circleCollider = gameObject.GetComponent<CircleCollider2D>();

        // 라인화인더 프리팹 찾아옴
        LineFinder = Resources.Load<GameObject>("Prefab/LineFinder");
    }

    // 마우스 위치에 오브젝트 계속 이동
    void FixedUpdate()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스값 계속 받아오고
        transform.position = new Vector2(mPosition.x, mPosition.y);      // 그 위치를 계속 따라다니게 만듬

        circleCollider.enabled = CMP; // CMP값에 따라 collider활성화 시킴
    }

    // 오브젝트랑 충돌했을때 collider이 살아 있고, 
    // 충돌 오브젝트가 Ground, Player, Monster, Trap면 Line_Finder 오브젝트 생성
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Trap" && CMP)  {
            GameObject.Find("GameManager").GetComponent<LineMaker>().cheackTwo = false; // 오브젝트랑 충돌하면 못그리게 하기 위해 cheackTwo를 비활성화 시킴

            CMP = false;
            circleCollider.enabled = col; // collider 비활성화

            Instantiate(LineFinder, transform.position, transform.rotation); // 현재 위치에 Line_Finder오브젝트 복제함
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Line_Maker : MonoBehaviour
{

    public GameObject Player;
    public GameObject linePrefab;

    // 라인
    LineRenderer Ir;
    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();
    List<Rigidbody2D> lines = new List<Rigidbody2D>();
    Rigidbody2D line;

    // player
    Rigidbody2D playerRIgidbody;
    private float gravityScale;

    // cnt는 그릴 수 있는 확인용(횟수 1번만)
    public int cnt;

    // 라인 주변에 오브젝트에 있는지 확인용
    public bool objectFind;

    void Start()
    {

        objectFind = true;
        cnt = 0;

        // 자신의 중력값과 자신의 값을 받는다
        playerRIgidbody = Player.GetComponent<Rigidbody2D>();
        gravityScale = playerRIgidbody.gravityScale;

        // 라인의 중력값
        line = linePrefab.GetComponent<Rigidbody2D>();

        // 시작하면 중력값과 자신의 떨어지는 속도 값을 0으로 넣어서 멈춘다
        playerRIgidbody.velocity = Vector2.zero;
        playerRIgidbody.gravityScale = 0;

    }

    void Update()
    {

        // 라인을 그리기 위한 코드

        // if, else if 조건문 비슷함
        // if문은 마우스를 누르면 그릴수 있는 횟수 확인
        // else if문은 그릴수 있는 횟수랑 오브젝트가 주변에 있는지 확인용(없으면 막그리다가 오브젝트 끼리 끼임)
        if (Input.GetMouseButtonDown(0) && cnt == 0)
        {

            GameObject go = Instantiate(linePrefab);

            // 라인 복제한거 lines리스트에 넣기
            lines.Add(go.GetComponent<Rigidbody2D>());

            Ir = go.GetComponent<LineRenderer>();
            col = go.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));   // 현재 마우스 위치값 리스트에 저장
            Ir.positionCount = 1;
            Ir.SetPosition(0, points[0]);



        }
        else if (Input.GetMouseButton(0) && cnt == 0 && objectFind)
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 밑에 있는 if문 방금 마우스 위치 확임 (없으면 같은 위치에 계속 라인 오브젝트 추가함)
            if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f)
            {
                // 마우스 좌표에 line 복제한거 넣음
                points.Add(pos);
                Ir.positionCount++;
                Ir.SetPosition(Ir.positionCount - 1, pos);
                col.points = points.ToArray();
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {

            // 마우스를 떼면 그리고 있던 마지막 포인트를 지운다
            points.Clear();

            // 마우스를 떼면 중력값을 넣는다
            playerRIgidbody.gravityScale = gravityScale;

            cnt = 1;

            // lines 리스트에 있는 중력 값을 0에서 1로 바꿈
            foreach (Rigidbody2D line in lines)
            {
                line.gravityScale = 1f;
            }
        }

        //if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
    }
}


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    // 타켓 플레이어
    public Transform target;

    // 몬스터 움직이는 속도
    private float speed;

    // 몬스터 살아있는지 여부 true면 살아 있는거
    private bool isLive;

    private float angle;

    void Start()
    {
        isLive = true;
        speed = 1;
    }

    void Update()
    {

        // 메인카메라에 있는 Line_Maker라는 스크립트에 있는 cnt가 1이랑 살아 있으면 움직임
        if (GameObject.Find("Main Camera").GetComponent<Line_Maker>().cnt == 1 && isLive)
        {

            // 타겟에 위치값 알아옴
            Vector3 dir = target.position - transform.position;

            // 타겟 방향으로 다가감
            transform.position += dir * speed * Time.deltaTime;

            // 타겟 방향으로 회전함
            //angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }

    // 1번 : 처음 부딛힐때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.CompareTag("태그"))
        //{
                        
        //}
    }

}

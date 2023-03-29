using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    void Update()
    {

        // 자신의 위치값을 계속 받는다
        Vector2 currentPosition = transform.position;

        //오브젝트의 Y의 값이 -5이상 떨어지만 실행
        if (currentPosition.y <= -5)
        {
            // 오브젝트를 (0,4) 좌표로 이동시킴
            transform.position = new Vector2(0, 4);

            
        }
    }

    // 1번 : 처음 부딪힐때
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //몬스터한테 닿으면
        if (collision.collider.CompareTag("Monster"))
        {
            Debug.Log("몬스터한테 죽음");
        }
        if (collision.collider.CompareTag("Spike"))
        {
            Debug.Log("가시에 박혀 뒤짐");
        }
    }

    //if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
}

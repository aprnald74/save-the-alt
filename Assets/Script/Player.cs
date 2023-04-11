using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    // 자신의 위치값을 받다가
    // y값이 -5이하로 떨어지면 0, 4로 이동
    void Update() {
        Vector2 currentPosition = transform.position;
        if (currentPosition.y <= -5) {
            transform.position = new Vector2(0, 4);
        }
    }

    // 닿은 오브젝트가 Monster이거나 Spike면 죽은걸 알려줌
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Monster")) {
            Debug.Log("몬스터한테 죽음");
        }
        if (collision.collider.CompareTag("Spike")) {
            Debug.Log("가시에 박혀 뒤짐");
        }
    }

    //if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
}

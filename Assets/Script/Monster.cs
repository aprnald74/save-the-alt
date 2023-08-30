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

    // 몬스터의 속도를 저장하기 위한 변수
    float speed;

    // 몬스터가 회전하기 위한 변수
    float angle;

    Animator animator;

    // 이 오브젝트의 콜리더 가져옴
    CircleCollider2D circleCollider2D;

    // Player태그를 가진 오브젝트를 저장하기 위한 리스트
    List<GameObject> foundObject;

    // 가장 가까운 Player을 저장하기 위한 변수
    GameObject enemy;

    ParticleSystem particle;

    float shortDis;

    void Start()
    {
        GameSetting();
    }

    void GameSetting()
    {
        foundObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        speed = 1;

        animator = GetComponent<Animator>();

        circleCollider2D = GetComponent<CircleCollider2D>();

        particle = GameObject.Find("Boom").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (foundObject[0] != null)
        {
            FindPlayer();

            // 그림을 다 그리면 움직이기 시작함
            if (!GameObject.Find("GameManager").GetComponent<LineMaker>().cheackOne)
            {
                // 플레이어 위치를 받아옴
                Vector3 dir = enemy.transform.position - transform.position;

                // 타겟 방향으로 다가감
                transform.position += dir * speed * Time.deltaTime;

                // 타겟 방향으로 회전함
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }
    }

    void FindPlayer()
    {

        shortDis = Vector2.Distance(gameObject.transform.position, foundObject[0].transform.position);

        enemy = foundObject[0];

        foreach (GameObject found in foundObject) {

            float Distence = Vector2.Distance(gameObject.transform.position, found.transform.position);

            if (Distence < shortDis) {
                enemy = found;
                shortDis = Distence;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap")) {
            particle.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
            particle.Play();
            StartCoroutine(ComeBack());
        }
    }

    IEnumerator ComeBack()
    {
        yield return new WaitForSeconds(0.3f);

        particle.transform.position = new Vector3(0, 10, 0);

        Destroy(gameObject);
    }
}
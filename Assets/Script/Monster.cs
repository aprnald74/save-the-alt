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

    // ������ �ӵ��� �����ϱ� ���� ����
    float speed;

    // ���Ͱ� ȸ���ϱ� ���� ����
    float angle;

    Animator animator;

    // �� ������Ʈ�� �ݸ��� ������
    CircleCollider2D circleCollider2D;

    // Player�±׸� ���� ������Ʈ�� �����ϱ� ���� ����Ʈ
    List<GameObject> foundObject;

    // ���� ����� Player�� �����ϱ� ���� ����
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

            // �׸��� �� �׸��� �����̱� ������
            if (!GameObject.Find("GameManager").GetComponent<LineMaker>().cheackOne)
            {
                // �÷��̾� ��ġ�� �޾ƿ�
                Vector3 dir = enemy.transform.position - transform.position;

                // Ÿ�� �������� �ٰ���
                transform.position += dir * speed * Time.deltaTime;

                // Ÿ�� �������� ȸ����
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
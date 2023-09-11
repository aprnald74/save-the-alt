using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private List<GameObject> foundObject; // Player�±׸� ���� ������Ʈ�� �����ϱ� ���� ����Ʈ

    private ParticleSystem particle; // ������Ʈ ������ ����� ��ƼŬ

    private SpriteRenderer thisImg; // ������Ʈ�� �̹���

    private GameObject enemy; // ���� ����� Player

    private float speed; // ������Ʈ �̵��ӵ�

    private float angle; // ������Ʈ ȸ��

    private float shortDis;


    /// <summary>
    /// ���� ���� ����
    /// </summary>
    void Awake()
    {

        thisImg = GetComponent<SpriteRenderer>();

        foundObject = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

        speed = 1;

        particle = GameObject.Find("Boom").GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// �׸��� �� �׸��� �÷��̾� ��ġ�� �ٰ���
    /// </summary>
    void Update()
    {
        if (foundObject[0] != null)
        {
            FindPlayer();
            
            if (!GameObject.Find("GameManager").GetComponent<LineMaker>().cheackOne)
            {
                
                Vector3 dir = enemy.transform.position - transform.position;

                transform.position += dir * speed * Time.deltaTime;

                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            }
        }
    }

    /// <summary>
    /// ���� ����� Player�� ã��, �� Player�� enemy�� ����
    /// </summary>
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

    /// <summary>
    /// �浹�� ������Ʈ�� Trap�̸� ��ƼŬ ���� ��Ű�� �ڸ�ƾ �۵���Ŵ
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap")) {
            if (this.gameObject.activeInHierarchy) {

                particle.transform.position = gameObject.transform.position;

                particle.Play();

                StartCoroutine(ComeBack());
            }
        }
    }

    /// <summary>
    /// �� ������Ʈ �̹����� ���ְ� ������Ʈ�� ���ִ� �ڵ�
    /// </summary>
    IEnumerator ComeBack()
    {
        thisImg.sprite = null;

        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }

    void OnDisable()
    {
        Debug.Log("�ı���");
    }
}
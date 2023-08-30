using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    SpriteRenderer thisImg;

    Sprite change_Icon;

    ParticleSystem particle;

    // �� ������Ʈ�� �ݸ��� ������
    CircleCollider2D circleCollider2D;

    void Start()
    {

        particle = GameObject.Find("Boom").GetComponent<ParticleSystem>();

        thisImg = GetComponent<SpriteRenderer>();

        change_Icon = Resources.Load<Sprite>("IMG/GyeongjuDie");

        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // �� ������Ʈ�� -5���Ϸ� �������� (0, 4)�� ��ġ �̵���Ŵ
    void Update() 
    {
        Vector2 currentPosition = transform.position;
        if (currentPosition.y <= -5) 
            transform.position = new Vector2(0, 4);
        
    }

    // ���� ������Ʈ�� Monster�̰ų� Spike�� ������ �˷���
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Monster"))
        {
            thisImg.sprite = change_Icon;
        }

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

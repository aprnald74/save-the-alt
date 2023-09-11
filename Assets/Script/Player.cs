using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour 
{

    private ParticleSystem particle; // ������Ʈ ������ ����� ��ƼŬ

    private SpriteRenderer thisImg; // ������Ʈ �̹���

    private Sprite change_Icon; // �ٲ� �̹���


    /// <summary>
    /// ���� ���� ����
    /// </summary>
    void Awake()
    {
        particle = GameObject.Find("Boom").GetComponent<ParticleSystem>();

        thisImg = GetComponent<SpriteRenderer>();

        change_Icon = Resources.Load<Sprite>("IMG/GyeongjuDie");

    }

    /// <summary>
    /// �� ������Ʈ�� -5 ���Ϸ� �������� �۵�
    /// </summary>
    void Update() 
    {
        Vector2 currentPosition = transform.position;
        if (currentPosition.y <= -5) 
            transform.position = new Vector2(0, 4);
        
    }

    /// <summary>
    /// �浹�� ������Ʈ�� Monster�̸� �̹��� �ٲٰ� <br />
    /// Trap�̸� ��ƼŬ ���� ��Ű�� �ڸ�ƾ �۵���Ŵ
    /// </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Monster")) {
            thisImg.sprite = change_Icon;
        }

        if (collision.collider.CompareTag("Trap")) 
            if (this.gameObject.activeInHierarchy) {

                particle.transform.position = gameObject.transform.position;

                particle.Play();

                StartCoroutine(ComeBack());
            } 
    }

    /// <summary>
    /// �� ������Ʈ �̹����� ���ְ� ���� Player���� ���̰� �� ������Ʈ�� ���ִ� �ڵ�
    /// </summary>
    IEnumerator ComeBack()
    {
        thisImg.sprite = null;

        yield return new WaitForSeconds(0.3f);

        GameObject.Find("GameManager").GetComponent<Stage>().nPlayer -= 1;

        Destroy(gameObject);
    }
}

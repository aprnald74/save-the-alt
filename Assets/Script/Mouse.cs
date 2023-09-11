using UnityEngine;

public class Mouse : MonoBehaviour
{
    [HideInInspector] public bool CMP; // CMP�� ���� collider�� ������ ����

    private CircleCollider2D circleCollider; // ������Ʈ�� collider

    private GameObject LineFinder; // LineFinder Prefab

    private Vector3 mPosition; // ������Ʈ�� ��ġ��

    /// <summary>
    /// ���� ���� ����
    /// </summary>
    void Awake()
    {
        CMP = true;

        circleCollider = gameObject.GetComponent<CircleCollider2D>();

        LineFinder = Resources.Load<GameObject>("Prefab/LineFinder");
    }

    /// <summary>
    /// ���콺 ��ġ�� ���� ������Ʈ ��� �̵�
    /// </summary>
    void FixedUpdate()
    {
        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mPosition.x, mPosition.y);

        circleCollider.enabled = CMP; // CMP���� ���� colliderȰ��ȭ ��Ŵ
    }

    /// <summary>
    /// �浹�� ������Ʈ�� Ground, Player, Monster, Trap�̶�� �±׸� �ް� �ְ�, CMP�� true��<br />
    /// �� �̻� ���׸��� �ϰ�, ���� ��ġ�� Line_Finder������Ʈ�� ������
    /// </summary>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" ||
            col.gameObject.tag == "Player" ||
            col.gameObject.tag == "Monster"||
            col.gameObject.tag == "Trap" && CMP)  {
            GameObject.Find("GameManager").GetComponent<LineMaker>().cheackTwo = false;

            CMP = false;
            circleCollider.enabled = col;
            
            Instantiate(LineFinder, transform.position, transform.rotation);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Line_Maker : MonoBehaviour
{

    public GameObject Player;
    public GameObject linePrefab;

    // ����
    LineRenderer Ir;
    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();
    List<Rigidbody2D> lines = new List<Rigidbody2D>();
    Rigidbody2D line;

    // player
    Rigidbody2D playerRIgidbody;
    private float gravityScale;

    // cnt�� �׸� �� �ִ� Ȯ�ο�(Ƚ�� 1����)
    public int cnt;

    // ���� �ֺ��� ������Ʈ�� �ִ��� Ȯ�ο�
    public bool objectFind;

    void Start() {
        objectFind = true;
        cnt = 0;

        // �ڽ��� �߷°��� �ڽ��� ���� �޴´�
        playerRIgidbody = Player.GetComponent<Rigidbody2D>();
        gravityScale = playerRIgidbody.gravityScale;

        // ������ �߷°�
        line = linePrefab.GetComponent<Rigidbody2D>();

        // �����ϸ� �߷°��� �ڽ��� �������� �ӵ� ���� 0���� �־ �����
        playerRIgidbody.velocity = Vector2.zero;
        playerRIgidbody.gravityScale = 0;

    }

    // ������ �׸��� ���� �ڵ�
    void Update() {

        // if���� ���콺�� Ŭ���ϸ� ���콺 ��ġ�� list�� ����
        if (Input.GetMouseButtonDown(0) && cnt == 0) {
            GameObject go = Instantiate(linePrefab);

            lines.Add(go.GetComponent<Rigidbody2D>());

            Ir = go.GetComponent<LineRenderer>();
            col = go.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Ir.positionCount = 1;
            Ir.SetPosition(0, points[0]);


        // ���콺 ��ġ���� ���� �����Ѱ� ����
        }  else if (Input.GetMouseButton(0) && cnt == 0 && objectFind) {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �ؿ� �ִ� if�� ��� ���콺 ��ġ Ȯ�� (������ ���� ��ġ�� ��� ���� ������Ʈ �߰���)
            if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f) {
                points.Add(pos);
                Ir.positionCount++;
                Ir.SetPosition(Ir.positionCount - 1, pos);
                col.points = points.ToArray();
            }
        // ���콺�� ���� �׸��� �ִ� ������ �����͸� �����, ���ο� �߷°��� �ְ�,
        // cnt�� 1�� �ٲ۴�
        } else if (Input.GetMouseButtonUp(0)) {
            points.Clear();

            playerRIgidbody.gravityScale = gravityScale;

            cnt = 1;

            foreach (Rigidbody2D line in lines) {
                line.gravityScale = 1f;
            }
        }
    }
}

//if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
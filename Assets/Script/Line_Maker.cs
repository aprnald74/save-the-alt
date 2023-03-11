using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Line_Maker : MonoBehaviour
{

    public GameObject Player;
    public GameObject linePrefab;

    //cnt�� �׸� �� �ִ� Ƚ�� 0�̸� �׸��� �ְ�, 1�̸� ���׸�
    public int cnt;

    //����
    LineRenderer Ir;
    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();
    List<Rigidbody2D> lines = new List<Rigidbody2D>();
    Rigidbody2D line;

    //player
    Rigidbody2D playerRIgidbody;

    private float gravityScale;

    private void Start()
    {

        cnt = 0;

        //�ڽ��� �߷°��� �ڽ��� ���� �޴´�
        playerRIgidbody = Player.GetComponent<Rigidbody2D>();
        gravityScale = playerRIgidbody.gravityScale;

        //������ �߷°�
        line = linePrefab.GetComponent<Rigidbody2D>();

        //�����ϸ� �߷°��� �ڽ��� �������� �ӵ� ���� 0���� �־ �����
        playerRIgidbody.velocity = Vector2.zero;
        playerRIgidbody.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {

        //������ �׸��� ���� �ڵ�
        if(Input.GetMouseButtonDown(0) && cnt == 0)
        {
            GameObject go = Instantiate(linePrefab);

            //���� �����Ѱ� lines����Ʈ�� �ֱ�
            lines.Add(go.GetComponent<Rigidbody2D>());

            Ir = go.GetComponent<LineRenderer>();
            col = go.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));                //���� ���콺 ��ġ�� ����Ʈ�� ����
            Ir.positionCount = 1;
            Ir.SetPosition(0, points[0]);

        }else if (Input.GetMouseButton(0) && cnt == 0)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //�ؿ� �ִ� if�� ������ �ڽ��� ��ġ�� �̹� ���� �ִµ� ����ؼ� ���� ��ġ�� ��ȯ��
            if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f && cnt == 0)
            {
                points.Add(pos);
                Ir.positionCount++;
                Ir.SetPosition(Ir.positionCount - 1, pos);
                col.points = points.ToArray();
            }

        }else if (Input.GetMouseButtonUp(0))
        {

            //���콺�� ���� �׸��� �ִ� ������ ����Ʈ�� �����
            points.Clear();

            //���콺 Ŭ���� ���� �߷°��� �ִ´�
            playerRIgidbody.gravityScale = gravityScale;


            cnt++;

            //lines ����Ʈ�� �ִ� �߷� ���� 0���� 1�� �ٲ�
            foreach (Rigidbody2D line in lines)
            {
                line.gravityScale = 1;
            }
        }

    //if(GameObject.Find("��ũ��Ʈ�� �����ϴ� ������Ʈ�̸�").GetComponent<��ũ��Ʈ �̸�>().���� == true)
    }
}


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.Video;

public class LineMaker : MonoBehaviour
{
    // cheackOne�� �ѹ��� �׸��� �ֵ��� �ϴ°�
    [HideInInspector]
    public bool cheackOne;

    // cheachTwo�� ���� �ֺ��� ������Ʈ�� �ִ��� Ȯ�ο�
    [HideInInspector]
    public bool cheackTwo;
    
    // cheackThree�� �׸��� �ִ��� Ȯ�ο�
    bool cheackThree;


    // ������ �����ϱ� ���� ����
    GameObject linePrefab;

    // ����
    LineRenderer Ir;
    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();
    List<Rigidbody2D> lines = new List<Rigidbody2D>();
    Rigidbody2D line;

    // player
    Rigidbody2D[] plRb;
    float gravityScale;
    List<GameObject> players = new List<GameObject>();



    // �������� �����ϱ� ���� ����
    Slider dGauge;

    // �������� ���簪�� ���� ����
    float current;

    // ������ �� ��ü�� �����ϱ� ���� ����
    GameObject fill;



    // ���� �� �������� Ȯ���ϱ� ���� ����
    [HideInInspector]
    public int stage;

    // ���帶�� �ִ�� �׸��� �ִ� Ƚ���� �����ϱ� ���� ����
    List<float> max = new List<float>();



    // InGame�� �ִ� ���� �����ϱ� ���� ����
    List<SpriteRenderer> thisImg = new List<SpriteRenderer>();

    // InGame�� �ִ� ���� �ٲ� �̹����� �����ϱ� ���� ����
    Sprite change_Icon;

    // thisImg�� ������ ����� ���� �����ϱ� ���� ����
    List<float> star = new List<float>();



    // List�� ����� ������ ����
    int num = 2;

    void Start() {

        GameSetting();

    }
    void GameSetting()
    {
        // ���� �ʵ忡 �ִ� �÷��̾ ��� ã��
        // ��� �÷��̾��� Rigidbody�� �����Ҽ� �ְ� �����
        // ��� �÷��̾��� �߷°��� �������� ���� 0���� ����
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        plRb = new Rigidbody2D[players.Count];
        for (int i = 0; i < players.Count; i++) {
            plRb[i] = players[i].GetComponent<Rigidbody2D>();
            plRb[i].velocity = Vector2.zero;
            plRb[i].gravityScale = 0;
        }

        // ���� ������ ã�ƿ�
        linePrefab = Resources.Load<GameObject>("Prefab/Line");

        // ������ �߷°�
        line = linePrefab.GetComponent<Rigidbody2D>();

        // �����̴� ������
        dGauge = GameObject.Find("Gauge").GetComponent<Slider>();

        // �����̴� ������ ������
        fill = GameObject.Find("Fill");

        // ��⼭ ���帶�� �׸��� �ִ� �ִ븦 ����
        max.AddRange(new float[] {500, 800, 700});
        
        // ���� ���������� �ִ�� �׸��� �ִ� ���� ����
        current = max[stage - 1];

        // 100�̶�� Star[0]�� 50 -> 100 -> 150
        // ���� ������Ʈ�� ã�� �� ������Ʈ�� ��������Ʈ�� thisImg�� ������
        for (int i = 1; i < 4; i++) {
            star.Add((max[stage - 1] / 4) * i);
            thisImg.Add(GameObject.Find("Star" + (4 - i)).GetComponent<SpriteRenderer>());
        }

        // �ٲ� �̹��� ã�ƿ�
        change_Icon = Resources.Load<Sprite>("IMG/Yes");

        cheackOne = true;
        cheackTwo = true;
        cheackThree = true;
    }

    // ������ �׸��� ���� �ڵ�
    void Update() {

        // �������� ���� �����ؼ� �����Ŵ
        dGauge.value = current / max[stage - 1];

        // ������ �������� ���� �̹����� �ٲ�
        if (num != -1) 
            if (current <= star[num])
                thisImg[num--].sprite = change_Icon;

        // �������� �� ���� Hpbar�� ���ְ� ���̻� ���׸��� ��
        if (current <= 0) {
            Destroy(fill);
            cheackThree = false;
        }

        LineDrow();

    }

    void LineDrow()
    {
        // if���� ���콺�� Ŭ���ϸ� ���콺 ��ġ�� list�� ����
        if (Input.GetMouseButtonDown(0) && cheackOne && cheackThree)
        {
            GameObject go = Instantiate(linePrefab);

            lines.Add(go.GetComponent<Rigidbody2D>());

            Ir = go.GetComponent<LineRenderer>();
            col = go.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Ir.positionCount = 1;
            Ir.SetPosition(0, points[0]);

            // ���콺 ��ġ���� ���� �����Ѱ� ����
        }
        else if (Input.GetMouseButton(0) && cheackOne && cheackTwo && cheackThree)
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �ؿ� �ִ� if�� ��� ���콺 ��ġ Ȯ�� (������ ���� ��ġ�� ��� ���� ������Ʈ �߰���)
            if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f)
            {

                // Distance�Լ��� Ȱ���Ͽ� �����̴� �Ÿ���ŭ �������� ����
                current = current - (Vector2.Distance(points[points.Count - 1], pos) * 20);

                points.Add(pos);
                Ir.positionCount++;
                Ir.SetPosition(Ir.positionCount - 1, pos);
                col.points = points.ToArray();
            }

            // ���콺�� ���� �׸��� �ִ� ������ �����͸� �����, �÷��̾�� ���ο� �߷��� �ٽ� �ִ´�
        }
        else if (Input.GetMouseButtonUp(0))
        {
            points.Clear();

            cheackOne = false;

            foreach (Rigidbody2D line in lines)
                line.gravityScale = 1f;

            for (int i = 0; i < players.Count; i++) {
                plRb[i].gravityScale = 1f;
            }
            col.enabled = true;
        }
    }
}
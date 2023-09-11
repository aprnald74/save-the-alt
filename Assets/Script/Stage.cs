using System.Collections;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [HideInInspector] public int nPlayer; // ���� �÷��̾� ��

    [HideInInspector] public int stage; // ���� ��������

    private int[] player = new int[] { 1, 1, 2 }; // �� �������� ���� �ִ� �÷��̾� ��

    private Canvas over; // ���� ���� �˾� â

    /// <summary>
    /// ���� ���� ����
    /// </summary>
    void Awake()
    {
        over = GameObject.Find("Setting").GetComponent<Canvas>();

        stage = 1;

        nPlayer = player[stage - 1];

        over.enabled = false;
    }

    /// <summary>
    /// ���� �÷��̾� ���� 0���� ������ ���� ���� ��Ŵ
    /// </summary>
    void Update()
    {

        if (nPlayer < 0) {
            StartCoroutine(GameOver());
        }
    }

    /// <summary>
    /// ���� ������ ����� �˾�â ���� �ð� ����
    /// </summary>
    IEnumerator GameOver()
    {

        yield return new WaitForSeconds(0.4f);

        over.enabled = true;

        Debug.Log("�۵���");
        Time.timeScale = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ڵ� ��� ������Ʈ�� �ִµ� ��ȿ���ϼ� �ִµ� ���� �������°� �� ��� �ۿ� ���� �Ф�
// �� �ڵ尡 �ִ� ������Ʈ�� ���콺�� �ö󰡸� �׸��� �ְ� �ϴ� objectFInd ������ false �ٲٰ�,
// ����� �ٽ� �׸��� �ְ� true�� �ٲ�
public class Object : MonoBehaviour
{
    public GameObject Line;

    private void Start()
    {
        Line.SetActive(false);
    }


    void OnMouseEnter()
    {
        Line.SetActive(true);
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
    }

    void OnMouseExit()
    {
        Line.SetActive(false);
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
    }
}

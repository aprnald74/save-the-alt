using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ڵ� ��� ������Ʈ�� �ִµ� ��ȿ���ϼ� �ִµ� ���� �������°� �� ��� �ۿ� ���� �Ф�
// �� �ڵ尡 �ִ� ������Ʈ�� ���콺�� �ö󰡸� �׸��� �ְ� �ϴ� objectFInd ������ false �ٲٰ�,
// ����� �ٽ� �׸��� �ְ� true�� �ٲ�
public class Object : MonoBehaviour
{

    public GameObject LineFinder;
    void OnMouseEnter()
    {
        LineFinder.SetActive(true); 
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
    }

    void OnMouseExit()
    {
        LineFinder.SetActive(false);
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ڵ� ��� ������Ʈ�� �ִµ� ��ȿ���ϼ� �ִµ� ���� �������°� �� ��� �ۿ� ���� �Ф�
// �� �ڵ尡 �ִ� ������Ʈ�� ���콺�� �ö󰡸� �׸��� �ְ� �ϴ� objectFInd ������ false �ٲٰ�,
// ����� �ٽ� �׸��� �ְ� true�� �ٲ�
public class Object : MonoBehaviour
{

    //public GameObject ObjectFind;

    void OnMouseEnter() // ���콺�� ������Ʈ ���� �ö󰡸�
    {
        //���콺�� Ŭ���ϰ� ������
        if (Input.GetMouseButton(0))
        {
            //ObjectFind.gameObject.SetActive(true);
            Debug.Log("true");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
        }
    }

    void OnMouseExit() // ���콺�� ������Ʈ�� ������
    {
        //���콺�� Ŭ���ϰ� ������
        if (Input.GetMouseButton(0))
        {
            //ObjectFind.gameObject.SetActive(false);
            Debug.Log("false");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        }
    }
}

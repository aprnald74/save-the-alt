using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ڵ� ��� ������Ʈ�� �ִµ� ��ȿ���ϼ� �ִµ� ���� �������°� �� ��� �ۿ� ���� �Ф�
// �� �ڵ尡 �ִ� ������Ʈ�� ���콺�� �ö󰡸� �׸��� �ְ� �ϴ� objectFInd ������ false �ٲٰ�,
// ����� �ٽ� �׸��� �ְ� true�� �ٲ�
public class Object : MonoBehaviour
{
    // ���콺�� ������Ʈ�� �����ϰ�, ���콺�� Ŭ���ϸ�
    void OnMouseEnter() {
        if (Input.GetMouseButton(0)) {
            Debug.Log("true");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
        }
    }

    // ���콺�� ������Ʈ�� ������, ���콺�� Ŭ���ϸ�
    void OnMouseExit() {
        if (Input.GetMouseButton(0)) {
            Debug.Log("false");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        }
    }
}

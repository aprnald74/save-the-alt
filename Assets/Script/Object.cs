using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ڵ� ��� ������Ʈ�� �ִµ� ��ȿ���ϼ� �ִµ� ���� �������°� �� ��� �ۿ� ���� �Ф�
// ���콺�� Ŭ���ϸ鼭, ������Ʈ ���� ���콺�� �ö󰡸� objectFInd ������ false �ٲٰ�,
// ����� true�� �ٲ�
public class Object : MonoBehaviour
{
    void OnMouseEnter() {
        if (Input.GetMouseButton(0)) {
            Debug.Log("true");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
        }
    }
    void OnMouseExit() {
        if (Input.GetMouseButton(0)) {
            Debug.Log("false");
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        }
    }
}

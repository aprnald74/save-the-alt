using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이코드 모든 오브젝트에 있는데 비효율일수 있는데 지금 생각나는게 이 방법 밖에 없음 ㅠㅠ
// 마우스를 클릭하면서, 오브젝트 위에 마우스가 올라가면 objectFInd 변수를 false 바꾸고,
// 벗어나면 true로 바꿈
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

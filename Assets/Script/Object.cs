using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이코드 모든 오브젝트에 있는데 비효율일수 있는데 지금 생각나는게 이 방법 밖에 없음 ㅠㅠ
// 이 코드가 있는 오브젝트에 마우스가 올라가면 그릴수 있게 하는 objectFInd 변수를 false 바꾸고,
// 벗어나면 다시 그릴수 있게 true로 바꿈
public class Object : MonoBehaviour
{

    public GameObject ObjectFind;

    void OnMouseEnter()
    {
        ObjectFind.gameObject.SetActive(true);
        Debug.Log("true");
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
    }

    void OnMouseExit()
    {
        ObjectFind.gameObject.SetActive(false);
        Debug.Log("false");
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
    }
}

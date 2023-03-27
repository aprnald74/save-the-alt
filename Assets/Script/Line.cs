using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Monster")
        {
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
        }
        else
        {
            GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
        }

    }
    //if(GameObject.Find("스크립트를 포함하는 오브젝트이름").GetComponent<스크립트 이름>().변수 == true)
}

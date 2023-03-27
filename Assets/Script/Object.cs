using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
    }

    private void OnMouseExit()
    {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
    }
}

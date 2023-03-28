using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private void OnMouseEnter()
    {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = false;
    }

    private void OnMouseExit()
    {
        GameObject.Find("MainCamera").GetComponent<Line_Maker>().objectFind = true;
    }
}

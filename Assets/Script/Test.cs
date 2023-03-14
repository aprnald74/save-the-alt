using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Update()
    {
        Collider2D[] collidres = Physics2D.OverlapCircleAll(transform.position, 0.53f);

        if (collidres.Length > 0)
        {
            Debug.Log("오브젝트 있음");
        }
        else
        {
            Debug.Log("오브젝트 없음");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.y <= -10)
        {
            // ������Ʈ�� (0,0,0) ��ǥ�� �̵���Ŵ
            transform.position = new Vector3(0, 0, 0);
        }
    }
}

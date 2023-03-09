using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        //자신의 위치값을 계속 받는다
        Vector2 currentPosition = transform.position;

        //오브젝트의 Y의 값이 -5이상 떨어지만 실행
        if (currentPosition.y <= -5)
        {
            // 오브젝트를 (0,4) 좌표로 이동시킴
            transform.position = new Vector2(0, 4);

            
        }
    }
}

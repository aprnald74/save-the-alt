using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        //�ڽ��� ��ġ���� ��� �޴´�
        Vector2 currentPosition = transform.position;

        //������Ʈ�� Y�� ���� -5�̻� �������� ����
        if (currentPosition.y <= -5)
        {
            // ������Ʈ�� (0,4) ��ǥ�� �̵���Ŵ
            transform.position = new Vector2(0, 4);

            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{

    public Transform target;
    public float speed;

    private bool isLive;

    void Start()
    {
        isLive = true;
        speed = 2;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        // Ÿ�� �������� �ٰ���
        transform.position += dir * speed * Time.deltaTime;

        // Ÿ�� �������� ȸ����
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
}

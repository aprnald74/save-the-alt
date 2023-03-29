using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFind : MonoBehaviour
{

    private float dx;
    private float dy;
    private float rotateDegree;

    void Start()
    {
        transform.localScale = new Vector2(1, 1);
        transform.position = new Vector2(0, 0);
    }

    void Update()
    {

        Vector3 mPosition = Input.mousePosition; // ���콺 ��ǥ ����
        Vector3 oPosition = transform.position; // ���� ������Ʈ ��ǥ ����

        // ī�޶� �ո鿡�� �ڷ� ���� �ֱ� ������, ���콺 position�� z�� ������ 
        // ���� ������Ʈ�� ī�޶���� z���� ���̸� �Է½������ �մϴ�.
        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        // ���콺�� ��ǥ�� target�� ����
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        // ������ ȸ�� �Լ��� 0���� 180 �Ǵ� 0���� -180�� ������ �Է� �޴µ� ���Ͽ�
        // (���� 270�� ���� ���� �Էµ� ���� ���������ϴ�.) ��ũź��Ʈ Atan2()�Լ��� ��� ���� 
        // ���� ��(180���� ����(3.141592654...)��)���� ��µǹǷ�
        // ���� ���� ������ ��ȭ�ϱ� ���� Rad2Deg�� �����־�� ������ �˴ϴ�.
        rotateDegree = Mathf.Atan2(target.y - oPosition.y, target.x - oPosition.x) * Mathf.Rad2Deg;

        // ������ ������ ���Ϸ� ȸ�� �Լ��� �����Ͽ� z���� �������� ���� ������Ʈ�� ȸ����ŵ�ϴ�.
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);

    }
}

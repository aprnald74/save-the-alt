using UnityEngine;

public class LineFind : MonoBehaviour
{

    private Vector3 mPosition; // ���콺 ��ǥ
    
    private float rotateDegree; // ������Ʈ ȸ��

    private float distance; // ������Ʈ�� ���콺�� �Ÿ� 

    // ���� ������ Ȱ���Ͽ� LineFinde������Ʈ�� ���콺 ��ġ�� ���� �ٴϸ鼭 �����̰� ��


    /// <summary>
    /// ���콺 ��ġ�� ������Ʈ���� �Ÿ��� ���Ѵ��� �� �Ÿ���ŭ ������Ʈ�� �ø��� ����
    /// </summary>
    void Update()
    {

        mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 oPosition = transform.position;
        Vector3 target = mPosition - transform.position;

        distance = (float)Mathf.Sqrt(Mathf.Pow(oPosition.x - mPosition.x, 2) + Mathf.Pow(oPosition.y - mPosition.y, 2));
        transform.localScale = new Vector2(distance, 1);

        rotateDegree = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(rotateDegree, Vector3.forward);

    }

    /// <summary>
    /// �� ������Ʈ�� �浹���� ����� �ٽ� �׸��� �� ������Ʈ�� ������
    /// </summary>
    void OnTriggerExit2D(Collider2D col)
    {
        GameObject.Find("GameManager").GetComponent<LineMaker>().cheackTwo = true;
        GameObject.Find("Mouse").GetComponent<Mouse>().CMP = true;

        Destroy(gameObject);
    }
}
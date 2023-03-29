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

        Vector3 mPosition = Input.mousePosition; // 마우스 좌표 저장
        Vector3 oPosition = transform.position; // 게임 오브젝트 좌표 저장

        // 카메라가 앞면에서 뒤로 보고 있기 때문에, 마우스 position의 z축 정보에 
        // 게임 오브젝트와 카메라와의 z축의 차이를 입력시켜줘야 합니다.
        mPosition.z = oPosition.z - Camera.main.transform.position.z;

        // 마우스의 좌표를 target에 저장
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

        // 오릴러 회전 함수를 0에서 180 또는 0에서 -180의 각도를 입력 받는데 반하여
        // (물론 270과 같은 값의 입력도 전혀 문제없습니다.) 아크탄젠트 Atan2()함수의 결과 값은 
        // 라디안 값(180도가 파이(3.141592654...)로)으로 출력되므로
        // 라디안 값을 각도로 변화하기 위해 Rad2Deg를 곱해주어야 각도가 됩니다.
        rotateDegree = Mathf.Atan2(target.y - oPosition.y, target.x - oPosition.x) * Mathf.Rad2Deg;

        // 구해진 각도를 오일러 회전 함수에 적용하여 z축을 기준으로 게임 오브젝트를 회전시킵니다.
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);

    }
}

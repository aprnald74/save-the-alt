using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFind : MonoBehaviour
{

    float angle;
    Vector2 target, mouse;

    // Start is called before the first frame update
    void Start()
    {

        target = transform.position;

        transform.position = new Vector2(0, 0);
        transform.localScale = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}

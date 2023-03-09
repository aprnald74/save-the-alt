using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Line_Maker : MonoBehaviour
{

    public GameObject Player;
    public GameObject linePrefab;

    LineRenderer Ir;
    EdgeCollider2D col;
    List<Vector2> points = new List<Vector2>();
    Rigidbody2D playerRIgidbody;

    private float gravityScale;

    private void Start()
    {
        playerRIgidbody = Player.GetComponent<Rigidbody2D>();
        gravityScale = playerRIgidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(linePrefab);
            Ir = go.GetComponent<LineRenderer>();
            col = go.GetComponent<EdgeCollider2D>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Ir.positionCount = 1;
            Ir.SetPosition(0, points[0]);
        }else if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f)
            {
                points.Add(pos);
                Ir.positionCount++;
                Ir.SetPosition(Ir.positionCount - 1, pos);
                col.points = points.ToArray();
            }

        }else if (Input.GetMouseButtonUp(0))
        {
            points.Clear();
        }

        //if(Input.GetKey(KeyCode.S))
        //{
        //    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        //}
        //if(Input.GetMouseButtonUp(0))
        //{
        //    Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        //}
        if (Input.GetKey(KeyCode.A))
        {
            //Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            //transform.position = lastPath;
            playerRIgidbody.velocity = Vector2.zero;
            playerRIgidbody.gravityScale = 0;
        }
        else
        {
            playerRIgidbody.gravityScale = gravityScale;
        }
    }
}

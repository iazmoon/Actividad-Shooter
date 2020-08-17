using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    float x;
    float y;
    float bottomlimit;
    float toplimit;
    float leftlimit;
    float rightlimit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        //Camara limits in the world space
        Vector3 bottomleft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomlimit = bottomleft.y;
        leftlimit = bottomleft.x;

        Vector3 topright = Camera.main.ViewportToWorldPoint(Vector3.one);
        toplimit = topright.y;
        rightlimit = topright.x;

        //limites del sprite
        bottomlimit += render.bounds.extents.y;
        toplimit -= render.bounds.extents.y;
        leftlimit += render.bounds.extents.x;
        rightlimit -= render.bounds.extents.x;


    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //transform.position += new Vector3(x, y, 0f) * speed * Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftlimit, rightlimit);

        //if (desiredPosition.x < leftlimit)
        //    desiredPosition.x = leftlimit;
        //else if (desiredPosition.x > rightlimit)
        //    desiredPosition.x = rightlimit;

        desiredPosition.y = Mathf.Clamp(desiredPosition.y, bottomlimit, toplimit);
        //if (desiredPosition.y < bottomlimit)
        //    desiredPosition.y = bottomlimit;
        //else if (desiredPosition.y > toplimit)
        //    desiredPosition.y = toplimit;

        //Calculate movement
        rb.MovePosition(desiredPosition);


    }
}

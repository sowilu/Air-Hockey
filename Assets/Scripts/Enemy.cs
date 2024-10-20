using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform ball;
    public float speed = 10;

    private Rigidbody2D rb;
    private float halfScreenX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        halfScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
    }

    void FixedUpdate()
    {
        var targetPosition = Vector3.MoveTowards(transform.position, ball.position, speed * Time.deltaTime);
        targetPosition.x = Mathf.Clamp(targetPosition.x, -Mathf.Infinity, halfScreenX);

        rb.MovePosition(targetPosition);
    }
}

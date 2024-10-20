using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 15;

    private Rigidbody2D rb;
    private float halfScreenX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        halfScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
    }

   
    void FixedUpdate()
    {
        var targetPos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        targetPos.x = Mathf.Clamp(target.position.x, -Mathf.Infinity, halfScreenX);
        rb.MovePosition(targetPos);
    }
}

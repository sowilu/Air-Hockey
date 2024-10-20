using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15;

    private Camera cam;
    private Rigidbody2D rb;
    private Vector3 worldPos;
    private float screenHalfX = 0;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        screenHalfX = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
    }

    void Update()
    {
        worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        //transform.position = worldPos;
        worldPos.x = Mathf.Clamp(worldPos.x, screenHalfX, Mathf.Infinity);
    }

    //fixed update is used for physics
    void FixedUpdate()
    {

        var targetPos = Vector2.MoveTowards(transform.position, worldPos, speed * Time.fixedDeltaTime);

        rb.MovePosition(targetPos);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 worldPosition;
    private Rigidbody2D rb;


    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        //transform.position = worldPosition;
    }

    //physics update
    void FixedUpdate()
    {
        rb.MovePosition(worldPosition);
    }
}

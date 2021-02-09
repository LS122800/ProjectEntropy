using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float blinkSpeed = 2.5f;

    public bool isDashing = false;

    public Rigidbody2D rb;

    Vector2 movement;
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("left shift"))
        {
            isDashing = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (isDashing)
        {
            rb.MovePosition(rb.position + movement * blinkSpeed);
            isDashing = false;
        }
    }
}
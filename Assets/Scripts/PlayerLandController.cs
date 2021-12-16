using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rayLength = 3;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 force = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, rb.velocity.y);
        rb.velocity = force;

        if (Input.GetAxis("Vertical") >0 || Input.GetAxis("Jump") > 0)
        {
            if (isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
                isGrounded = false;
            }
        } else if (Input.GetKey(KeyCode.S))
        {
            
        }
        
        var hit = Physics2D.Raycast(transform.position, -transform.up, rayLength, 1);
        if (hit) 
            isGrounded = true;

        Debug.DrawRay(transform.position, -transform.up * rayLength, Color.red);
    }
}

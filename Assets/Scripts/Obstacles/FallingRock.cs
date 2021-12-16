using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float gravity = 1;
    private bool damaged;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fall()
    {
        rb.gravityScale = gravity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Damage player
            if (!damaged)
            {
                Debug.Log("Hit player");
                damaged = true;
            }
        }
    }
}

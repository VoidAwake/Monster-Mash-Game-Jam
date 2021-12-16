using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    [SerializeField] private float gravity = 1;
    [SerializeField] private float despawnTime = 3f;
    private float timer;
    private Rigidbody2D rb;
    private bool damaged;
    private bool fallen;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!fallen) return;
        
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Fall()
    {
        rb.gravityScale = gravity;
        fallen = true;
        timer = despawnTime;
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

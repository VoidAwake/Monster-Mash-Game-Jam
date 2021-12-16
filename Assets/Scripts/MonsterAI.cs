using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;

    [SerializeField] private bool damagable;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player)
        {
            var velocity = (player.transform.position - transform.position) * moveSpeed;
            rb.MovePosition(transform.position + velocity * Time.deltaTime);
        }
    }

    public void OnDamagable()
    {
        damagable = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FallingRocks"))
        {
            // Kill monster
        }
    }
}

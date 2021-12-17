using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;

    [SerializeField] private bool damagable;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(!player
                ? "Player doesn't exist or doesn't have player tag"
                : "player wasn't set manually, used gameobject.find");
        }
    }

    void FixedUpdate()
    {
        if (player)
        {
            var direction = (player.transform.position - transform.position).normalized;
            var velocity = direction * moveSpeed;
            rb.MovePosition(transform.position + velocity * Time.deltaTime);
            
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

            spriteRenderer.flipY = direction.x < 0;
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

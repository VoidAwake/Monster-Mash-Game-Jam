using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private MonsterState initialState;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float backOffSpeed;
    [SerializeField] private float backOffDistance;
    
    [SerializeField] private bool damagable;
    private SpriteRenderer spriteRenderer;
    public enum MonsterState
    {
        Idle,
        Chase,
        BackOff
    }

    private MonsterState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = (player.transform.position - transform.position).normalized;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        switch (currentState)
        {
            case MonsterState.Chase:
                transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed);
                //var direction = (player.transform.position - transform.position).normalized;
                //float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

                break;
            case MonsterState.BackOff:
                if (Vector3.Distance(transform.position, player.position) < backOffDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, -player.position, backOffSpeed);
                    transform.rotation = Quaternion.Euler(0f, 0f, -rotZ);
                }
                else
                {
                    ChangeState(MonsterState.Idle);
                }

                break;
        }
        spriteRenderer.flipY = direction.x < 0;
    }

    public void ChangeState(MonsterState monsterState)
    {
        currentState = monsterState;
    }
    
    // TODO: React to walls
    public void OnDamagable()
    {
        damagable = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FallingRocks") && damagable)
        {
            if (col.gameObject.GetComponent<FallingRock>().fallen)
            {
                // Kill monster
            }
        }
    }
}

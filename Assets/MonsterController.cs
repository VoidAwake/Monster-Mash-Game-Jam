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
    public enum MonsterState
    {
        Idle,
        Chase,
        BackOff
    }

    private MonsterState currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case MonsterState.Chase:
                transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed);
                break;
            case MonsterState.BackOff:
                if (Vector3.Distance(transform.position, player.position) < backOffDistance)
                {
                    transform.position = Vector3.MoveTowards(transform.position, -player.position, backOffSpeed);
                }
                else
                {
                    ChangeState(MonsterState.Idle);
                }

                break;
        }
    }

    public void ChangeState(MonsterState monsterState)
    {
        currentState = monsterState;
    }
    
    // TODO: React to walls
}

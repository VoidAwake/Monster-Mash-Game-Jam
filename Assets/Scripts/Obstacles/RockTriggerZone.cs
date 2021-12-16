using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTriggerZone : MonoBehaviour
{
    [SerializeField] private FallingRock[] fallingRocks;
    [SerializeField] private float delay;
    private float timer;
    private bool falling;
    private int rockIndex = 0;

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (falling)
        {
            if (timer <= 0)
            {
                if (fallingRocks[rockIndex])
                {
                    fallingRocks[rockIndex].Fall();
                    rockIndex++;
                    timer = delay;
                }
                else
                {
                    Debug.Log("Falling rock doesn't exit");
                }
                
                if (rockIndex >= fallingRocks.Length)
                {
                    falling = false;
                    _collider2D.enabled = false;
                }
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            falling = true;
        }
    }

    private void OnValidate()
    {
        fallingRocks = GetComponentsInChildren<FallingRock>();
    }
}

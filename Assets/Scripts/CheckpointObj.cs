using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointObj : MonoBehaviour
{
    private bool Activated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !Activated) CheckpointManager.Instance.OnCheckpointReach(gameObject);
    }
}

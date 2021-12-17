using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager _instance;

    public static CheckpointManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    [SerializeField] private GameObject player;
    
    [SerializeField] private CheckpointObj currCheckpoint;

    [ContextMenu("PlayerReset")]
    public void OnRespawn()
    {
        if (currCheckpoint != null) player.transform.position = currCheckpoint.transform.position;
    }
    
    public void OnCheckpointReach(CheckpointObj checkpointObj)
    {
        currCheckpoint = checkpointObj;
    }
}

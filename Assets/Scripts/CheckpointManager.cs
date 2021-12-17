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
        
        OnRespawn();
    }
    

    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject currCheckpoint;

    [SerializeField] private string currCheckPref;
    
    [ContextMenu("PlayerReset")]
    public void OnRespawn()
    {
        var checkpoint = PlayerPrefs.GetString(currCheckPref);
        if (currCheckpoint != null || checkpoint != null)
        {
            currCheckpoint = GameObject.Find(checkpoint);
            player.transform.position = currCheckpoint.transform.position;
        }
    }
    
    public void OnCheckpointReach(GameObject checkpointObj)
    {
        currCheckpoint = checkpointObj;
        PlayerPrefs.SetString(currCheckPref, currCheckpoint.name);
    }
}

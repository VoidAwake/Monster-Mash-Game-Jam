using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementController;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField] private MovementType movementType;

    private MovementController movementController;

    void Start()
    {
        movementController = FindObjectOfType<MovementController>();

        if (!movementController)
        {
            Debug.LogWarning("Could not find MovementController");
        }
    }
    private void OnTriggerEnter2D()
    {
        movementController.ChangeMovementType(movementType);
    }
}

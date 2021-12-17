using UnityEngine;
using static MovementController;

public class MovementTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 swimPosition;
    [SerializeField] private Vector2 walkPosition;

    private MovementController movementController;

    void Start()
    {
        movementController = FindObjectOfType<MovementController>();

        if (!movementController)
        {
            Debug.LogWarning("Could not find MovementController");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (movementController.CurrentMovementType)
        {
            case MovementType.Land:
                movementController.ChangeMovementType(MovementType.Underwater);

                other.transform.position = transform.position + Vector3.Scale(swimPosition, transform.localScale);
                
                break;
            case MovementType.Underwater:
                movementController.ChangeMovementType(MovementType.Land);

                other.transform.position = transform.position + Vector3.Scale(walkPosition, transform.localScale);

                break;
        }
    }
}

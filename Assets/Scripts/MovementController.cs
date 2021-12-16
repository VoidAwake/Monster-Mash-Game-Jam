using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public enum MovementType {
        Surface,
        Underwater
    }

    [SerializeField] private UnderwaterMovement underwaterMovement;
    [SerializeField] private SurfaceMovement surfaceMovement;
    [SerializeField] private MovementType startingMovementType;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMovementType(startingMovementType);

        surfaceMovement.dive.AddListener(OnDive);
    }

    private void OnDive()
    {
        ChangeMovementType(MovementType.Underwater);
    }

    public void ChangeMovementType (MovementType movementType)
    {
        surfaceMovement.enabled = false;
        underwaterMovement.enabled = false;

        switch (movementType)
        {
            case MovementType.Surface:
                surfaceMovement.enabled = true;
                break;
            case MovementType.Underwater:
                underwaterMovement.enabled = true;
                break;
        }
    }
}

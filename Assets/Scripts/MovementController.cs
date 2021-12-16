using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public enum MovementType {
        Land,
        Surface,
        Underwater
    }

    [SerializeField] private LandMovement landMovement;
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
        landMovement.enabled = false;
        surfaceMovement.enabled = false;
        underwaterMovement.enabled = false;

        switch (movementType)
        {
            case MovementType.Land:
                landMovement.enabled = true;
                break;
            case MovementType.Surface:
                surfaceMovement.enabled = true;
                break;
            case MovementType.Underwater:
                underwaterMovement.enabled = true;
                break;
        }
    }
}

using System;
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
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public MovementType CurrentMovementType { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        ChangeMovementType(startingMovementType);

        surfaceMovement.dive.AddListener(OnDive);
    }

    private void FixedUpdate()
    {
        switch (CurrentMovementType)
        {
            case MovementType.Land:
                // TODO: If we have jump gotta move this
                animator.SetFloat("LandVel", rb.velocity.magnitude);
                spriteRenderer.flipX = rb.velocity.x < 0;
                break;
            case MovementType.Surface:
                break;
            case MovementType.Underwater:
                animator.SetFloat("SwimVel", rb.velocity.magnitude);
                spriteRenderer.flipY = transform.rotation.z > 0;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnDive()
    {
        ChangeMovementType(MovementType.Underwater);
    }

    public void ChangeMovementType (MovementType movementType)
    {

        Debug.Log(movementType);
        landMovement.enabled = false;
        surfaceMovement.enabled = false;
        underwaterMovement.enabled = false;

        switch (movementType)
        {
            case MovementType.Land:
                landMovement.enabled = true;
                animator.SetBool("OnLand", true);
                break;
            case MovementType.Surface:
                surfaceMovement.enabled = true;
                break;
            case MovementType.Underwater:
                animator.SetBool("OnLand", false);
                underwaterMovement.enabled = true;
                spriteRenderer.flipX = false;
                break;
        }

        CurrentMovementType = movementType;
    }
}

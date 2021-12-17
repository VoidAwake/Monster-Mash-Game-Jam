using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnderwaterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private float swimForceMultiplier;
    [SerializeField] private float turnForceMultiplier;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float holdWPeriod;
    [SerializeField] private OxygenTank oxygenTank;
    [SerializeField] private float swimmingOxygenCost;


    private float timeSinceLastWPress;

    private void Start()
    {
        timeSinceLastWPress = 0;
    }

    private void OnEnable()
    {
        rigidbody.velocity = Vector2.zero;

        oxygenTank.IsReducing = true;
    }

    private void OnDisable()
    {
        oxygenTank.IsReducing = false;
    }

    void Update()
    {
        // Press W to swim
        if (Input.GetKeyDown(KeyCode.W))
        {
            Swim();
        }
        else
        {
            timeSinceLastWPress += Time.deltaTime;
        }

        // Hold W to keep swimming
        if (Input.GetKey(KeyCode.W))
        {
            if (timeSinceLastWPress > holdWPeriod)
            {
                Swim();
            }
        }

        // Turning

        rigidbody.AddTorque(-Input.GetAxis("Horizontal") * turnForceMultiplier);
    }

    private void Swim()
    {
        rigidbody.AddForce(transform.up * curve.Evaluate(timeSinceLastWPress) * swimForceMultiplier);

        //Debug.Log(curve.Evaluate(timeSinceLastWPress) * swimForceMultiplier);

        timeSinceLastWPress = 0;

        oxygenTank.ReduceOxygenLevel(swimmingOxygenCost);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Air"))
        {
            oxygenTank.IsReducing = false;
            oxygenTank.IsRenewing = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Air"))
        {
            oxygenTank.IsReducing = true;
            oxygenTank.IsRenewing = false;
        }
    }
}

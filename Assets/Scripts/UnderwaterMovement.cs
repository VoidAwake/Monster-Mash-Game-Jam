using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnderwaterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float swimForceMultiplier;
    [SerializeField] private float turnForceMultiplier;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float holdWPeriod;


    private float timeSinceLastWPress;

    private void Start()
    {
        timeSinceLastWPress = 0;
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
    }
}

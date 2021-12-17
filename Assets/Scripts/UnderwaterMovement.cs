using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

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

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] swims;

    [SerializeField] private float pointDmg = 1f;
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
        var power = transform.up * curve.Evaluate(timeSinceLastWPress) * swimForceMultiplier;
        rigidbody.AddForce(power);
        
        audioSource.PlayOneShot(swims[Random.Range(0, swims.Length-1)]);
        audioSource.volume = Mathf.Clamp(curve.Evaluate(timeSinceLastWPress), 0.2f, 1f);
    
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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PointyRock"))
        {
            oxygenTank.ReduceOxygenLevel(pointDmg);
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

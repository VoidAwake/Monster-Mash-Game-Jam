using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float swimForce;

    void Update()
    {
        // Hold W to move forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce(transform.forward * swimForce);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {

        }

        
    }
}

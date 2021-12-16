using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SurfaceMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float diveForce;
    [SerializeField] private float swimForceMultiplier;

    public UnityEvent dive;


    private void OnEnable()
    {
        // TODO: Move player to water surface

        // Reset player rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // Lock rotation and y position
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnDisable()
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Move left and right
        rigidbody.AddForce(transform.right * Input.GetAxis("Horizontal") * swimForceMultiplier);

        // Dive
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidbody.constraints = RigidbodyConstraints2D.None;

            rigidbody.AddForce(-transform.up * diveForce);

            dive.Invoke();
        }
    }
}

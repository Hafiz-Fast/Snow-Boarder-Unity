using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField] float acceleration = 1f; // Acceleration amount
    [SerializeField] float deceleration = 1f;
    [SerializeField] float maxSpeed = 20f; // Maximum speed
    [SerializeField] SurfaceEffector2D surfaceEffector; // Reference to the SurfaceEffector2D component
    private bool isGrounded = true; // Is the player on the ground
    [SerializeField] private float currentSpeed = 0f; // Current speed of the player

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && isGrounded)
        {
            // Accelerate the player
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }
        else
        {
            // Decelerate the player to a stop
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }

        // Set the speed of the SurfaceEffector2D
        surfaceEffector.speed = currentSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

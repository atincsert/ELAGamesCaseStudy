using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float downwardVelocity = 500f, upwardVelocity = 1000f;
    [SerializeField] private float forwardVelocity = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        VerticalMovement();
        HorizontalMovement();
    }

    private void VerticalMovement()
    {
        bool isPressed = Input.GetMouseButton(0);
        if (isPressed)
        {
            rb.AddForce(Vector3.up * upwardVelocity * Time.fixedDeltaTime, ForceMode.Force);
        }
        else
        {
            rb.AddForce(Vector3.down * downwardVelocity * Time.fixedDeltaTime);
        }
    }

    private void HorizontalMovement()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, Mathf.Clamp(rb.velocity.z, forwardVelocity, forwardVelocity));
       //rb.AddForce(Vector3.forward * forwardVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // TODO: Show Game Over UI and Retry button
            Destroy(gameObject);
        }
    }
}

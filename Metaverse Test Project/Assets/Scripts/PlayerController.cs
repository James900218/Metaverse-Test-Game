using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform forcePoint;

    [Header("Acceleration")]
    public InputActionReference Throttle;
    private float movementInput;
    public float movementForce = 10f;

    public float maxSpeed = 10f;
    public float waterDrag = 2f;

    [Header("Steering")]
    public InputActionReference Steering;
    public float rotationForce = 500f;
    private float moveRotation;

    public float turnTorque = 500f;
    public float turnDrag = 2f;

    private Vector3 movementDirection;

    private void Update()
    {
        movementInput = Throttle.action.ReadValue<float>();
        moveRotation = Steering.action.ReadValue<float>();

        movementDirection = rigidBody.transform.forward;
    }

    private void FixedUpdate()
    {
        MoveBoat();
        TurnBoat();
    }

    private void MoveBoat()
    {
        if (rigidBody.velocity.magnitude < maxSpeed)
        {
            rigidBody.AddForceAtPosition(movementDirection * (movementInput * movementForce), forcePoint.position);

        }
    }

    private void TurnBoat()
    {
        rigidBody.AddTorque(Vector3.up * moveRotation * turnTorque);
        //rigidBody.transform.Rotate(0f, moveRotation * (movementInput * rotationForce), 0f);
    }

    private void applyDrag()
    {
        Vector3 horizontalVelocity = rigidBody.velocity;
        horizontalVelocity.y = 0;
        rigidBody.AddForce(-horizontalVelocity * waterDrag);
    }
}

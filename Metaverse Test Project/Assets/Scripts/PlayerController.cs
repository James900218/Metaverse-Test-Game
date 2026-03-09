using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // this script allows the player to control the Powerboat
    // boat rigidbody
    public Rigidbody rigidBody;

    [Header("Acceleration")]
    public InputActionReference Throttle;
    private float movementInput; // from input action, 1 is forward and -1 is back
    public float movementForce = 10f; // force applied when accelerating

    public float maxSpeed = 10f;
    public float waterDrag = 2f; //resistance when moving forward

    [Header("Steering")]
    public InputActionReference Steering;
    public float rotationForce = 500f; //strength of rotating
    private float moveRotation; // input value

    public float turnTorque = 500f; // how strong the force is applied when rotating, high torque is quicker rotation
    public float turnDrag = 2f; // resistance when rotating

    private Vector3 movementDirection;

    private void Update()
    {
        // read input values from input action
        movementInput = Throttle.action.ReadValue<float>();
        moveRotation = Steering.action.ReadValue<float>();

        movementDirection = rigidBody.transform.forward;
    }

    private void FixedUpdate()
    {
        MoveBoat();
        TurnBoat();
        ApplyDrag();
    }

    private void MoveBoat()
    {
        // apply forward force
        if (rigidBody.velocity.magnitude < maxSpeed)
        {
            rigidBody.AddForce(movementDirection * (movementInput * movementForce));

        }
    }

    private void TurnBoat()
    {
        // apply rotational force
        float speedFactor = (rigidBody.velocity.magnitude / maxSpeed);
        rigidBody.AddTorque(Vector3.up * moveRotation * turnTorque * speedFactor);
    }

    private void ApplyDrag()
    {
        //apply resisting forces
        Vector3 horizontalVelocity = rigidBody.velocity;
        horizontalVelocity.y = 0;
        rigidBody.AddForce(-horizontalVelocity * waterDrag);
    }
}

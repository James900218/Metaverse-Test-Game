using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform forcePoint;
    public float movementForce = 10f;
    public float rotationForce = 500f;

    public InputActionReference Throttle;
    public InputActionReference Steering;

    private float movementInput;
    private float moveRotation;

    private Vector3 movementDirection;

    private void Update()
    {
        movementInput = Throttle.action.ReadValue<float>();
        moveRotation = Steering.action.ReadValue<float>();
        
    }

    private void FixedUpdate()
    {
        movementDirection = rigidBody.transform.forward;

        rigidBody.AddForceAtPosition(movementDirection * (movementInput * movementForce), forcePoint.position);
        rigidBody.transform.Rotate(0f, moveRotation * (movementInput * rotationForce), 0f);
        //rigidBody.AddForceAtPosition(moveRotation * rigidBody.transform.right * rotationForce / 100f, forcePoint.position);
    }
}

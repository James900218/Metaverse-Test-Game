using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    // this script makes the owning object simulate buoyancy by floating up and down periodically

    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    public void FixedUpdate()
    {
        //float waveHeight = WaterManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < 0f)
        {
            //if submerged, create a buoyancy forced based on how far submerged the object is -clamped 0,1- times the displacement amount
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
        }

        //float waveHeight = WaterManager.instance.GetWaveHeight(transform.position.x);
        //if (transform.position.y < waveHeight)
        //{
        //    //if submerged, create a buoyancy forced based on how far submerged the object is -clamped 0,1- times the displacement amount
        //    float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
        //    rigidBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    //this script creates a bezier curve using an algorithm and gizmos to visualise the curve

    [SerializeField] private Transform[] controlPoints;  //Array to hold the points of the curve

    private Vector3 gizmosPosition; //position of each gizmo sphere to be drawn along the curve

    public float sphereRadius = 0.25f; //radius of the spheres

    private void OnDrawGizmos()
    {
        for (float i = 0; i <= 1; i += 0.05f)
        {
            //getting the positions of the spheres along the curve, equation is from wikipedia of Bezier Curves
            gizmosPosition = Mathf.Pow(1 - i, 3) * controlPoints[0].position +
                3 * Mathf.Pow(1 - i, 2) * i * controlPoints[1].position +
                3 * (1 - i) * Mathf.Pow(i, 2) * controlPoints[2].position +
                Mathf.Pow(i, 3) * controlPoints[3].position;

            Gizmos.DrawSphere(gizmosPosition, sphereRadius);
        }

        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, controlPoints[0].position.y, controlPoints[0].position.z),
            new Vector3(controlPoints[1].position.x, controlPoints[1].position.y, controlPoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, controlPoints[2].position.y, controlPoints[2].position.z),
            new Vector3(controlPoints[3].position.x, controlPoints[3].position.y, controlPoints[3].position.z));
    }

}



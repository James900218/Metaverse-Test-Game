using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierCurve : MonoBehaviour
{
    [SerializeField] private Transform[] routes;

    private int numOfRoutes;

    private float temp;

    private Vector3 followPosition;

    [SerializeField] private float followSpeed = 0.02f;

    private bool coroutineAllowed;

    [SerializeField] private bool followRotation;

    private Vector3 previousPosition;

    [SerializeField] private float rotationSpeed;

    void Start()
    {
        temp = 0;
        numOfRoutes = 0;
        coroutineAllowed = true;

        previousPosition = transform.position;
    }

    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(followRoute(numOfRoutes));
        }
    }

    private void FixedUpdate()
    {
        if (followRotation)
        {
            Vector3 moveDir = (transform.position - previousPosition);
            moveDir.y = 0f;

            // using a very small direction can cause unstable rotations
            if (moveDir.sqrMagnitude > 0.0001f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(moveDir.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }

            previousPosition = transform.position;
        }

        transform.position += transform.right * Mathf.Sin(Time.time * 0.5f) * 0.1f;
    }

    private IEnumerator followRoute(int _numOfRoutes)
    {
        coroutineAllowed = false;

        Vector3 point0 = routes[_numOfRoutes].GetChild(0).position;
        Vector3 point1 = routes[_numOfRoutes].GetChild(1).position;
        Vector3 point2 = routes[_numOfRoutes].GetChild(2).position;
        Vector3 point3 = routes[_numOfRoutes].GetChild(3).position;

        while (temp < 1)
        {
            temp += Time.deltaTime * followSpeed;

            followPosition = Mathf.Pow(1 - temp, 3) * point0 +
                3 * Mathf.Pow(1 - temp, 2) * temp * point1 +
                3 * (1 - temp) * Mathf.Pow(temp, 2) * point2 +
                Mathf.Pow(temp, 3) * point3;

            transform.position = new Vector3(followPosition.x, transform.position.y, followPosition.z);
            yield return new WaitForEndOfFrame();
        }

        temp = 0;

        numOfRoutes += 1;

        if (numOfRoutes > routes.Length - 1)
        {
            numOfRoutes = 0;
        }

        coroutineAllowed = true;
    }
}

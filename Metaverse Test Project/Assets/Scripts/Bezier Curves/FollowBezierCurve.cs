using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierCurve : MonoBehaviour
{
    [SerializeField] private Transform[] routes;

    private int numOfRoutes;

    private float temp;

    private Vector3 followPosition;

    [SerializeField] private float followSpeed;

    private bool coroutineAllowed;

    void Start()
    {
        temp = 0;
        numOfRoutes = 0;
        followSpeed = 0.5f;
        coroutineAllowed = true;
    }

    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(followRoute(numOfRoutes));
        }
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

            transform.position = followPosition;
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

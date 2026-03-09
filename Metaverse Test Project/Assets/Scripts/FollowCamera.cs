using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followTransform;
    private Camera mainCamera;

    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = followTransform.position - cameraOffset;
    }
}

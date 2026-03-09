using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //this script attaches the camera to an object with an offset
    public Transform followTransform;
    private Camera mainCamera;

    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = followTransform.position - cameraOffset;
    }
}

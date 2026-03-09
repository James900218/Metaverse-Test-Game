using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompleteGame : MonoBehaviour
{
    private BoxCollider boxCollider;
    public Timer timer;
    public string Tag;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag(Tag))
        {

        }
    }
}

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
        timer.HideTimer(true);
    }

    private void FixedUpdate()
    {
        if (timer.IsTimeUp())
        {
            Debug.Log("WIN");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>().CompareTag(Tag))
        {
            timer.HideTimer(false);
            timer.StartTimer();
        }

        Debug.Log("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>().CompareTag(Tag))
        {
            timer.HideTimer(true);
            timer.ResetTimer();
            timer.StopTimer();
        }

        Debug.Log("Exit");
    }
}

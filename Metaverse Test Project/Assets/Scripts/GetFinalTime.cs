using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFinalTime : MonoBehaviour
{
    public Text minutes;

    public Text seconds;

    public Timer timer;

    private int iMinutes;

    private int iSeconds;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetTime()
    {
        timer.StopTimer();
        iMinutes = timer.GetTimeMinutes();
        iSeconds = timer.GetTimeSeconds();

        minutes.text = iMinutes.ToString();
        seconds.text = iSeconds.ToString();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

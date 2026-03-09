using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text minutesText;
    public Text secondsText;

    private int minutes;
    private int seconds;

    private float counter;

    public bool shouldCountDown = false;
    public int countDownDurationInSeconds;

    private void Start()
    {
        minutes = 0;
        seconds = 0;
        counter = 0;

        if (shouldCountDown)
        {
            SetCountDown();
        }
    }

    private void Update()
    {
        if (shouldCountDown)
        {
            if (minutes <= 0 & seconds <= 0)
            {
                Debug.Log("Timer Has Ended");
                return;
            }
            else CountDown();
        }
        else
        {
            CountUp();
        }



    }

    private void SetSeconds()
    {
        secondsText.text = seconds.ToString();
    }

    private void SetMinutes()
    {
        minutesText.text = minutes.ToString();
    }

    private void SetCountDown()
    {
        int remainder = countDownDurationInSeconds % 60;
        minutes = ((countDownDurationInSeconds - remainder) / 60);
        seconds = remainder;

        SetMinutes();
        SetSeconds();
    }

    private void CountUp()
    {
        if (counter < 1)
        {
            counter += Time.deltaTime;

            if (counter >= 1)
            {
                if (seconds == 59)
                {
                    minutes++;
                    SetMinutes();

                    seconds = 0;
                    SetSeconds();

                    counter = 0;
                }
                else
                {
                    seconds++;
                    SetSeconds();
                    counter = 0;
                }

            }
        }
    }

    private void CountDown()
    {
        if (counter < 1)
        {
            counter += Time.deltaTime;

            if (counter >= 1)
            {
                if (seconds == 0)
                {
                    minutes--;
                    SetMinutes();

                    seconds = 59;
                    SetSeconds();

                    counter = 0;
                }
                else
                {
                    seconds--;
                    SetSeconds();
                    counter = 0;
                }
            }
        }
    }
}

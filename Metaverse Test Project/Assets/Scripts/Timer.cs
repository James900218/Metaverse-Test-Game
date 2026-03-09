using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // This script provides a timer that displays into a UI text box. The timer has a variety of functionality to be called from 
    // different classes

    // Text elements
    public Text minutesText;
    public Text secondsText;

    // color for the text, used to scale the Alpha down so it is hidden
    private Color minutesTextAlpha;
    private Color secondsTextAlpha;

    private int minutes;
    private int seconds;

    // float that resets whenever time > 1 has past
    private float counter;

    // switch to countdown instead of count up
    public bool shouldCountDown = false;
    public int countDownDurationInSeconds;

    // should the timer start on active / is active?
    public bool timerStartsActive = false;
    private bool timerIsActive;

    // should timer be hidden, alpha set to 0
    public bool hideTimer = false;

    private void Start()
    {
        minutes = 0;
        seconds = 0;
        counter = 0;

        minutesTextAlpha = minutesText.color;
        secondsTextAlpha = secondsText.color;

        if (shouldCountDown)
        {
            SetCountDown();
        }

        if (timerStartsActive)
        {
            timerIsActive = true;
        }
    }

    private void Update()
    {
        // countdown timer unless the timer has finished
        // count up timer is indefinite
        if (timerIsActive)
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

    }

    private void SetSeconds()
    {
        // set UI text (seconds)
        secondsText.text = seconds.ToString();
    }

    private void SetMinutes()
    {
        // set UI text (minutes)
        minutesText.text = minutes.ToString();
    }

    private void SetCountDown()
    {
        //get countdown duration and set the timer
        int remainder = countDownDurationInSeconds % 60;
        minutes = ((countDownDurationInSeconds - remainder) / 60);
        seconds = remainder;

        SetMinutes();
        SetSeconds();
    }

    private void CountUp()
    {
        //if delta time is > 1s, tick up and if seconds is equal to 1 minute, minutes tick up and seconds reset
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
        // samde as CountUp except numbers tick down from set duration
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

        if (hideTimer)
        {
            HideTimer(true);
        }
        else if (!hideTimer)
        {
            HideTimer(false);
        }
    }

    public void StartTimer()
    {
        timerIsActive = true;
    }

    public void StopTimer()
    {
        timerIsActive = false;
    }

    public void ResetTimer()
    {
        // set timer to 0 or back to duration
        if (shouldCountDown)
        {
            minutes = 0;
            seconds = countDownDurationInSeconds;
            SetCountDown();
        }
        else
        {
            minutes = 0;
            seconds = 0;
        }
    }

    public int GetTimeLeft()
    {
        //returns remains time in seconds
        return seconds + (minutes * 60);
    }

    public bool IsTimeUp()
    {
        if (GetTimeLeft() <= 0)
        {
            return true;
        }
        else return false;
    }

    public void HideTimer(bool _isHidden)
    {
        // changes text color alpha value, 0 is hidden, 1 is opaque
        if (_isHidden)
        {
            minutesTextAlpha.a = 0;
            minutesText.color = minutesTextAlpha;

            secondsTextAlpha.a = 0;
            secondsText.color = secondsTextAlpha;
        }
        else
        {
            minutesTextAlpha.a = 1;
            minutesText.color = minutesTextAlpha;

            secondsTextAlpha.a = 1;
            secondsText.color = secondsTextAlpha;
        }

    }

    public int GetTimeMinutes()
    {
        return minutes;
    }

    public int GetTimeSeconds()
    {
        return seconds;
    }
}

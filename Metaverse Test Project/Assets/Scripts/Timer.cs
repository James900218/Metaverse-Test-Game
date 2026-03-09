using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text minutesText;
    public Text secondsText;

    private Color minutesTextAlpha;
    private Color secondsTextAlpha;

    private int minutes;
    private int seconds;

    private float counter;

    public bool shouldCountDown = false;
    public int countDownDurationInSeconds;

    public bool timerStartsActive = false;
    private bool timerIsActive;

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
}

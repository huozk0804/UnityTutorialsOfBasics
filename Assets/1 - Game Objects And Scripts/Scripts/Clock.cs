using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    float hoursToDegrees = -30, minutesToDegrees = -6f, secondsToDegrees = -6f;
    [SerializeField] private Transform hoursPivot, minutesPivot, secondsPivot;

    //[SerializeField]
    //Transform minutesPivot;

    //[SerializeField]
    //Transform secondsPivot;

    private void Update()
    {
        // Debug.Log(DateTime.Now.Hour);
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation =
            Quaternion.Euler(0, 0, hoursToDegrees * (float) time.TotalHours);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, minutesToDegrees * (float) time.TotalMinutes);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * (float) time.TotalSeconds);
    }
}
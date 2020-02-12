using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform _hoursTransform, _minutesTransform, _secondsTransform;
    public bool _continuous;
    const float DEGREES_PER_HOUR = 30F,
        DEGREES_PER_MINUTE = 6f,
        DEGREES_PER_SECOND = 6f;

    private void Awake()
    {
        if (_continuous)
            placeArmsContinuous();
        else
            placeArmsDiscrete();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_continuous)
            placeArmsContinuous();
        else
            placeArmsDiscrete();
    }

    void placeArmsDiscrete()
    {
        DateTime now = DateTime.Now;
        _hoursTransform.localRotation = Quaternion.Euler(0f, now.Hour * DEGREES_PER_HOUR, 0f);
        _minutesTransform.localRotation = Quaternion.Euler(0f, now.Minute * DEGREES_PER_MINUTE, 0f);
        _secondsTransform.localRotation = Quaternion.Euler(0f, now.Second * DEGREES_PER_SECOND, 0f);
    }
    void placeArmsContinuous()
    {
        TimeSpan now = DateTime.Now.TimeOfDay;
        _hoursTransform.localRotation = Quaternion.Euler(0f, (float)now.TotalHours * DEGREES_PER_HOUR, 0f);
        _minutesTransform.localRotation = Quaternion.Euler(0f, (float)now.TotalMinutes * DEGREES_PER_MINUTE, 0f);
        _secondsTransform.localRotation = Quaternion.Euler(0f, (float)now.TotalSeconds * DEGREES_PER_SECOND, 0f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    private bool _canT;
    private int _timerInt;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void Init(Timer timer)
    {
        timer.OnTimerGet += UpdateTimer;
    }

    public void UpdateTimer(int value)
    {
        _timerText.text = value.ToString();
    }
}

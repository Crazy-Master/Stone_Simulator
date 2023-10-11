using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _totalTime;
    private float _timer;
    private int _deltaTime;
    private bool _run;
    private List<IСhangeTime> _iСhangeTime = new List<IСhangeTime>();
    public event Action OnTimerStop;
    public event Action<int> OnTimerGet;
    public void Init(TimerUI timerUI)
    {
        timerUI.GetComponent<TimerUI>().Init(this);
    }

    private void  FixedUpdate()
    {
        if (_timer > 0)
        {
            _timer = _timer - Time.deltaTime;
            var timerInt = (int)_timer;
            if (_deltaTime != timerInt)
            {
                OnTimerGet?.Invoke(timerInt);
                _deltaTime = timerInt;
            }
        }
        else if (_run == true)
        {
            _run = false;
            OnTimerStop?.Invoke();
        }
    }
    

    public void StartTimer(float value)
    {
        _totalTime = value;
         _timer = value;
         _deltaTime = (int)value;
        _run = true;
    }
    
    public void СhangeTime(float value)
    {
        _timer -= value;
    }

    public void SetСhangeTime(IСhangeTime change)
    {
        _iСhangeTime.Add(change);
        change.OnСhangeTime += СhangeTime;
    }
    
    public void СhangePercentTime(float value)
    {
        _timer -= _timer*value/100f;
    }

    private void OnDestroy()
    {
        foreach (var change in _iСhangeTime)
        {
            change.OnСhangeTime -= СhangeTime;
        }
    }
}


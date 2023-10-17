using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _totalTime;
    private float _timer;
    private int _deltaTime;
    private List<IСhangeTime> _iСhangeTime = new List<IСhangeTime>();
    private int _gameOver;

    public event Action OnTimerStop;
    public event Action<int> OnTimerGet;
    public event Action<float> OnСhangeTimerGet;
    public void Init(TimerUI timerUI)
    {
        timerUI.GetComponent<TimerUI>().Init(this);
        if (!PlayerPrefs.HasKey("Victory"))
        {
            PlayerPrefs.SetInt("Victory", -1);
        }
        _gameOver = PlayerPrefs.GetInt("Victory");
    }

    private void  FixedUpdate()
    {
        if (_timer >= 0)
        {
            _timer += Time.deltaTime * _gameOver;
            var timerInt = (int)_timer;
            if (_deltaTime != timerInt)
            {
                OnTimerGet?.Invoke(timerInt);
                _deltaTime = timerInt;
            }
        }
        else if (PlayerPrefs.GetInt("Victory")==-1)
        {
            _timer = 0;
            OnTimerGet?.Invoke((int)_timer);
            _gameOver = 1;
            PlayerPrefs.SetInt("Victory", _gameOver);
            OnTimerStop?.Invoke();
        }
    }
    

    public void StartTimer(float value)
    {
        _totalTime = value;
         _timer = value;
         _deltaTime = (int)value;
    }
    
    public void СhangeTime(float value)
    {
        _timer -= value;
        OnСhangeTimerGet?.Invoke(value);
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


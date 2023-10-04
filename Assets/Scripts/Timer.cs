using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _totalTime;
    private float _timer;
    private int _timerInt;
    private bool _run;
    public event Action<int> OnTimerStop;
    public event Action<int> OnTimerGet;

    [SerializeField] private GameObject _prefub;
    [SerializeField] private Transform _canvas;

    private void Start()
    {
        StartTimer(20);
        var timeObj = Instantiate(_prefub, _canvas);
        timeObj.GetComponent<TimerUI>().Init(this);
    }

    private void  FixedUpdate()
    {
        if (_timer > 0)
        {
            _timer = _timer - Time.deltaTime;
            _timerInt = (int)_timer;
            OnTimerGet?.Invoke(_timerInt);
        }
        else if (_run == true)
        {
            _run = false;
            OnTimerStop?.Invoke(_timerInt);
        }
    }
    

    public void StartTimer(float value)
    {
        _totalTime = value;
        _timer = value;
        _run = true;
    }
    
    public void СhangeTime(float value)
    {
        _timer -= value;
    }
    
    public void СhangePercentTime(float value)
    {
        _timer -= _totalTime*value/100f;
    }
}


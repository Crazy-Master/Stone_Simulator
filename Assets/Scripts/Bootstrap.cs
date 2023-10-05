using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelObj;
    
    [SerializeField] private GameObject _canvas;
    
    
    private GameObject _activeObj;
    private Timer _timer;
    
    private void Start()
    {
        PlayerPrefs.DeleteAll(); // при билде убрать 
        if (!PlayerPrefs.HasKey("lvl"))
        {
            PlayerPrefs.SetInt("lvl",1);
        }
        CreateWorld();
        CreateUI();
    }

    private void CreateWorld()
    {
        if (_activeObj != null)
        {
            Destroy(_activeObj);
        }
        _activeObj = Instantiate(_levelObj[PlayerPrefs.GetInt("lvl")-1]);
    }
    
    private void CreateUI()
    {
        GameObject canvas = Instantiate(_canvas);
        _timer = canvas.AddComponent<Timer>();
        _timer.Init(canvas.GetComponentInChildren<TimerUI>());
        _timer.StartTimer(5); //  в зависимости от уровня;
        _timer.OnTimerStop += NextLevel;
    }

    private void NextLevel()
    {
        PlayerPrefs.SetInt("lvl",PlayerPrefs.GetInt("lvl")+1);
        CreateWorld();
        _timer.StartTimer(5);
    }
}



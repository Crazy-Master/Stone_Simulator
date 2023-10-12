using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levelObj;
    [SerializeField] private GameObject _stoneObj;
    
    [SerializeField] private GameObject _canvas;
    
    
    private GameObject _activeObj;
    private Timer _timer;
    
    private void Start()
    {
        CreateUI();
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        var Stone = Instantiate(_stoneObj, new Vector3(22,5,19), Quaternion.identity);
    }

    private void CreateUI()
    {
        _timer = GameMeneger.instance.timer;
        _timer.Init(_canvas.GetComponentInChildren<TimerUI>());
        _timer.StartTimer(86400); //  в зависимости от уровня;
    }
    
}



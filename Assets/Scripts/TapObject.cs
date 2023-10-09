using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapObject : MonoBehaviour, IPointerClickHandler, IСhangeTime
{
    public event Action<float> OnСhangeTime;
    [SerializeField] float _changeTime = 0.5f;
    [SerializeField] GameObject _textEffect;

    private void Start()
    {
        GameMeneger.instance.timer.SetСhangeTime(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnСhangeTime?.Invoke(_changeTime);
        TimeEffect();
        Debug.Log("НАЖАЛ");
    }

    private void  TimeEffect()
    {
        Instantiate(_textEffect, transform);
    }
    
}

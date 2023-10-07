using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapObject : MonoBehaviour, IPointerClickHandler, IСhangeTime
{
    public event Action<float> OnСhangeTime;
    private const float _changeTime = 0.5f;

    private void Start()
    {
        GameMeneger.instance.timer.SetСhangeTime(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnСhangeTime?.Invoke(_changeTime);
        Debug.Log("НАЖАЛ");
    }
    
}

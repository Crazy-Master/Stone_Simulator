using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Core.AudioSystem;

public class TapObject : MonoBehaviour, IPointerClickHandler, IСhangeTime
{
    public event Action<float> OnСhangeTime;
    [SerializeField] private float _changeTime = 0.5f;
    [SerializeField] private ESound _eSound;


    private void Start()
    {
        GameMeneger.instance.timer.SetСhangeTime(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManagerView.Instance.PlaySound(_eSound);
        OnСhangeTime?.Invoke(_changeTime);
    }
    
}

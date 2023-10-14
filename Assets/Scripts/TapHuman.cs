using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Core.AudioSystem;

public class TapHuman : MonoBehaviour, IPointerDownHandler, IСhangeTime
{
    [SerializeField] private ParticleSystem _particleEffHuman;
    [SerializeField] private ESound _eSound;
    [SerializeField] private AIEnemy _ai;
    public event Action<float> OnСhangeTime;
    [SerializeField] private float _changeTime = -70;

    
    private void Start()
    {
        GameMeneger.instance.timer.SetСhangeTime(this);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManagerView.Instance.PlaySound(_eSound);
        _ai.GoHuman();
        
        OnСhangeTime?.Invoke(_changeTime);
        _particleEffHuman.Play();


    }
    
    
}

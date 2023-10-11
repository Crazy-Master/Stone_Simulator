using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Core.AudioSystem;

public class TapObject : MonoBehaviour, IPointerClickHandler, IСhangeTime
{
    public event Action<float> OnСhangeTime;
    [SerializeField] private float _changeTime = 0.5f;
    [SerializeField] private GameObject _textEffect;
    [SerializeField] private ESound _eSound;

    [SerializeField] private GameObject _pointSpawnEffect;

    private void Start()
    {
        GameMeneger.instance.timer.SetСhangeTime(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManagerView.Instance.PlaySound(_eSound);
        OnСhangeTime?.Invoke(_changeTime);
        TimeEffect();
        Debug.Log("НАЖАЛ");
    }

    private void  TimeEffect()
    {
        var effect = Instantiate(_textEffect, _pointSpawnEffect.transform);
        effect.GetComponent<TapEffect>().Init(_changeTime);
    }
    
}

using UnityEngine;
using UnityEngine.EventSystems;
using Core.AudioSystem;

public class TapHuman : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ESound _eSound;
    [SerializeField] private AIEnemy _ai;


    

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManagerView.Instance.PlaySound(_eSound);
        _ai.GoHuman();
        
    }
}

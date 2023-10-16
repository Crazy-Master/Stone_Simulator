using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuotesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string[] _quotes;
    private int _number;

    private void Start()
    {
        GameMeneger.instance.timer.OnTimerGet += Timer;
    }

    public void Timer(int time)
    {
        if (time % 100 != 0) return;
        ChangeQuote();
    }

    public void ChangeQuote()
    {
        int namber;
        do
        {
            namber = Random.Range(0, _quotes.Length);
        } while (_number == namber);
        _number = namber;
        _text.text = _quotes[_number];
    }
    
    private void OnDisable()
    {
        GameMeneger.instance.timer.OnTimerGet -= Timer;
    }
}

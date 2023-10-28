using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using Random = UnityEngine.Random;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;
    private int _timeFix = 41;
    private Timer _timer;
    [SerializeField] private QuotesManager _quotes;

    private void Start()
    {
        _timer = GameMeneger.instance.timer;
    }

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }

    public void AdButtonCul()
    {
        int timeFix = Random.Range(10, _timeFix);
        _timer.СhangePercentTime(timeFix);
        _quotes.ChangeQuote();
    }
}

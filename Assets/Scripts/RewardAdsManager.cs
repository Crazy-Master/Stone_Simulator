using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using Random = UnityEngine.Random;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;
    private int _timeFix = 30;
    private Timer _timer;
    
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
        _timer.СhangePercentTime(_timeFix);
    }
}

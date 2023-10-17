using TMPro;
using UnityEngine;
public class TimerUI : MonoBehaviour
{
    private bool _canT;
    private int _timerInt;
    [SerializeField] private TextMeshProUGUI _timerText;
        
    [SerializeField] private GameObject _textEffect;

    [SerializeField] private GameObject _pointSpawnEffect;


    private Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        timer.OnTimerGet += UpdateTimer;
        timer.OnСhangeTimerGet += СhangeTimeUI;
    }

    public void UpdateTimer(int value)
    {
        int days = (int)(value / 86400) % 365;
        int hors = (int)(value / 3600) % 24;
        int minutes = (int)(value / 60) % 60;
        int seconds = (int)(value % 60);
        if (days > 0)
        {
            _timerText.text = days + ":" + hors + ":" + minutes + ":" + seconds;
            return;
        }

        if (hors > 0)
        {
            _timerText.text = hors + ":" + minutes + ":" + seconds;
            return;
            
        }

        if (minutes > 0)
        {
            _timerText.text = minutes + ":" + seconds;
            return;            
        }

        if (seconds > 0)
        {
            _timerText.text = seconds.ToString();
        }
    }

    private void OnDestroy()
    {
        _timer.OnTimerGet -= UpdateTimer;  
        _timer.OnСhangeTimerGet -= СhangeTimeUI;
    }
    
    public void СhangeTimeUI(float value)
    {
        if (value < 0)
        {
            gameObject.GetComponent<GetTokensVFXController>().AddTokensVFX((int)value, Input.mousePosition);
        }
        else
        {
            gameObject.GetComponent<GetTokensVFXController>().RemoveTokensVFX((int)value);
        }
        /*var effect = Instantiate(_textEffect, _pointSpawnEffect.transform);
        effect.GetComponent<TapEffect>().Init(value);*/
    }
}

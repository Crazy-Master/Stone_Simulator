using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    private bool _canT;
    private int _timerInt;
    [SerializeField] private TextMeshProUGUI _timerText;

    private Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        timer.OnTimerGet += UpdateTimer;
    }

    public void UpdateTimer(int value)
    {
        _timerText.text = value.ToString();
    }

    private void OnDestroy()
    {
        _timer.OnTimerGet -= UpdateTimer;  
    }
}

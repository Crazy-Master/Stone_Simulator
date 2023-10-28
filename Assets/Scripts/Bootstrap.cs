using UnityEngine;
using YG;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _stoneObj;
    
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _victoryWindow;
    
    private GameObject _activeObj;
    private Timer _timer;
    public YandexGame sdk;
    private void Start()
    {
        CreateUI();
        CreatePlayer();
    }



    private void CreatePlayer()
    {
        Instantiate(_stoneObj, new Vector3(22,5,19), Quaternion.identity);
    }

    private void CreateUI()
    {
        _timer = GameMeneger.instance.timer;
        _timer.Init(_canvas.GetComponentInChildren<TimerUI>());
        if (!PlayerPrefs.HasKey("Timer"))
        {
            PlayerPrefs.SetInt("Timer", 86400);
        }

        _timer.StartTimer(PlayerPrefs.GetInt("Timer"));
        _timer.OnTimerGet += GetTimer;
        _timer.OnTimerStop += Victory;
    }

    private void OnDestroy()
    {
        _timer.OnTimerGet -= GetTimer;   
        _timer.OnTimerStop -= Victory;
    }

    public void GetTimer(int time)
    {
        if ((time % 10) == 0 )
        {
            PlayerPrefs.SetInt("Timer", time); 
        }
    }

    public void Victory()
    {
        _victoryWindow.SetActive(true);
    }
}



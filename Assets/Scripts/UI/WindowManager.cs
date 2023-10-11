using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject _windowPause;
    [SerializeField] private GameObject _windowGame;



    public void PauseMenuAct()
    {
        _windowPause.SetActive(true);
        _windowGame.SetActive(false);
    }

    public void PauseMenuDeAct()
    {
        _windowPause.SetActive(false);
        _windowGame.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("бярюк х бшьек");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject _windowPause;


    public void PauseMenuAct()
    {
        _windowPause.SetActive(true);
    }

    public void PauseMenuDeAct()
    {
        _windowPause.SetActive(false);
    }
}

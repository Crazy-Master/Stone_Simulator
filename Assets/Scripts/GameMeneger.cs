using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMeneger : MonoBehaviour
{
    public static GameMeneger instance;
    public Timer timer;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else //if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioSettings : MonoBehaviour
{
    public Slider audioSlide;
    public AudioSource audioSrc;
    private float musicVolume = 1f;

    [SerializeField] GameObject _pauseWindow;


    void Update()
    {
        if (_pauseWindow.activeSelf)
        { 
        musicVolume = audioSlide.value;
        audioSrc.volume = musicVolume;
        PlayerPrefs.SetFloat("VolumePreference", musicVolume);
         }    
    }
}

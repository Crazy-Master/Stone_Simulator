using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.AudioSystem
{    
    public enum ESound
    { 
        Tap
    }

    public enum EMusic
    {
        MusicOne,
        MusicTwo,
        MusicThree,
        MusicFore,
        MusicFive, 
        MusicSix, 
        MusicSeven, 
        MusicEight
    }
    
    

    [Serializable]
    public class SettingSound
    {
        public ESound eSound;
        public AudioClip soundClip;
    }

    [Serializable]
    public class SettingMusic
    {
        public EMusic eMusic;
        public AudioClip[] musicClips;
        public AudioClip musicClip;
    }
    
    [CreateAssetMenu(fileName = "AudioDataBase", menuName = "Settings/AudioDataBase", order = 0)]
    public class AudioDataBase: ScriptableObject
    {
        [SerializeField] private List<SettingSound> sound;
        [SerializeField] private List<SettingMusic> music;

        public List<SettingSound> SettingSounds => sound;
        public List<SettingMusic> SettingMusic => music;
        
    }
}
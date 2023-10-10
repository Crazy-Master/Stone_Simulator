using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.AudioSystem
{
    [RequireComponent(typeof(AudioSource))]
    public class BgMusic : MonoBehaviour
    {
        [SerializeField] private EMusic music;

        private AudioSource _audioSource;

        private int _pastValue = 0;
        private AudioClip[] _audioClips;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            SetMusic();
            _audioSource.Play();
        }

        private void SetMusic()
        {
            if (AudioManager.Instance.GetMusic(music) == null)
            {
                _audioClips = AudioManager.Instance.GetMusicArray(music);
                _audioSource.clip = _audioClips[0];
                NextClip();
            }
            else
            {
                _audioSource.clip = AudioManager.Instance.GetMusic(music);
                _audioSource.loop = true;
            }  
        }

        private void OnAudioClipEnd()
        {
            _pastValue++;
            if (_audioClips.Length == _pastValue)
            {
                _pastValue = 0;
            }
            _audioSource.clip = _audioClips[_pastValue];
            NextClip();
            _audioSource.Play();
        }

        private void NextClip()
        {
            Invoke(nameof(OnAudioClipEnd), _audioClips[_pastValue].length);
        }
    }
}
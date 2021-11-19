using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;
    [SerializeField] private Slider sliderForEffects;

    
    public static bool changeSound;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void ChangeMasterVolume(float value)
    {
        _musicSource.volume = value; // music
        //AudioListener.volume = value; //all sound
    }

    public void ToggleEffects()
    {
        _effectsSource.mute = !_effectsSource.mute;

        if(_effectsSource.mute)
        {
            changeSound = true;
            AudioListener.volume = 0;
            sliderForEffects.value = 0.318f;
        }
        else
        {
            changeSound = false;
            sliderForEffects.value = 1;
            AudioListener.volume = 0.5f;
        }
    }

    public void ToogleMusic()
    {
        _musicSource.mute = !_musicSource.mute;

        if (_musicSource.mute)
        {
            changeSound = true;           
        }
        else
        {
            changeSound = false;
        }
    }
}

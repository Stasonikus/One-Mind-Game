using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSeetting : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MucisPref";
    private static readonly string SoundsEffectsPref = "SoundsEffectPref";
    private int firstPlayInt;
    public Slider musicSlider, soundsEffectsSlider;
    private float musicFloat, soundsEffectsFloat;
    public AudioSource musicAudio;
    public AudioSource[] soundsEffectsAudio;

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            musicFloat = 0.25f;
            soundsEffectsFloat = 0.75f;
            musicSlider.value = musicFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SoundsEffectsPref, soundsEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = musicFloat;
            soundsEffectsFloat = PlayerPrefs.GetFloat(SoundsEffectsPref);
            soundsEffectsSlider.value = soundsEffectsFloat;
        }
    }

    public void SaveSoundsSettings()
    {
        PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundsEffectsPref, soundsEffectsSlider.value);
    }

    private void OnApplicationFocus(bool Infocus)
    {
        if (!Infocus)
        {
            SaveSoundsSettings();
        }
    }

    public void UpdateSounds()
    {
        musicAudio.volume = musicSlider.value;
        for (int i = 0; i < soundsEffectsAudio.Length; i++)
        {
            soundsEffectsAudio[i].volume = soundsEffectsSlider.value;
        }
    }
}

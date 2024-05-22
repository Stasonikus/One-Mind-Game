using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
    private static readonly string MusicPref = "MucisPref";
    private static readonly string SoundsEffectsPref = "SoundsEffectPref";
    private float musicFloat, soundsEffectsFloat;
    public AudioSource musicAudio;
    public AudioSource[] soundsEffectsAudio;

    private void Awake()
    {
        LevelSoundsSettings();
    }

    private void LevelSoundsSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundsEffectsFloat = PlayerPrefs.GetFloat(SoundsEffectsPref);

        musicAudio.volume = musicFloat;
         
        for (int i = 0; i < soundsEffectsAudio.Length; i++)
        {
            soundsEffectsAudio[i].volume = soundsEffectsFloat;

        }
    }
}

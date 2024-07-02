using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioSettings audioSettings;
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        InitializeSliders();
        LoadAudioSettings();
    }

    public void SetMasterVolume(float volume)
    {
        audioSettings.masterVolume = volume;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioSettings.musicVolume = volume;
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioSettings.sfxVolume = volume;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    private void LoadAudioSettings()
    {
        SetMasterVolume(audioSettings.masterVolume);
        SetMusicVolume(audioSettings.musicVolume);
        SetSFXVolume(audioSettings.sfxVolume);
    }

    private void InitializeSliders()
    {
        if (masterSlider != null)
        {
            masterSlider.value = audioSettings.masterVolume;
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
        }

        if (musicSlider != null)
        {
            musicSlider.value = audioSettings.musicVolume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = audioSettings.sfxVolume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
    }
}
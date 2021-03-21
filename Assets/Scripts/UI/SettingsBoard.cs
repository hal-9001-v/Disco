using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsBoard : MonoBehaviour{
    public AudioMixer audioMixer;

    [Header("Sliders")]
    const string globalVolume = "GlobalVolume";
    const float globalMax = 0;
    const float globalMin = -80;
    const float globalDefaultValue = 0;
    public Slider globalSlider;

    const string musicVolume = "MusicVolume";
    const float musicMax = 0;
    const float musicMin = -80;
    const float musicDefaultValue = 0;
    public Slider musicSlider;

    const string effectsVolume = "EffectsVolume";
    const float effectsMax = 0;
    const float effectsMin = -80;
    const float effectsDefaultValue = 0;
    public Slider effectsSlider;

    const string dialogueVolume = "DialogueVolume";
    const float dialogueMax = 20;
    const float dialogueMin = -80;
    const float dialogueDefaultValue = 0;
    public Slider dialogueSlider;

    public void Start()
    {
        float volumeReceiver;

        globalSlider.minValue = globalMin;
        globalSlider.maxValue = globalMax;
        audioMixer.GetFloat(globalVolume,  out volumeReceiver);
        globalSlider.value = volumeReceiver;

        musicSlider.maxValue = musicMax;
        musicSlider.minValue = musicMin;
        audioMixer.GetFloat(musicVolume, out volumeReceiver);
        musicSlider.value = volumeReceiver;

        effectsSlider.minValue = effectsMin;
        effectsSlider.maxValue = effectsMax;
        audioMixer.GetFloat(effectsVolume, out volumeReceiver);
        effectsSlider.value = volumeReceiver;

        dialogueSlider.minValue = dialogueMin;
        dialogueSlider.maxValue = dialogueMax;
        audioMixer.GetFloat(dialogueVolume, out volumeReceiver);
        dialogueSlider.value = volumeReceiver;


    }

    public void setGlobalVolume(float value)
    {
        audioMixer.SetFloat(globalVolume, value);
    }

    public void setMusicVolume(float value)
    {
        audioMixer.SetFloat(musicVolume, value);
    }

    public void setEffectsVolume(float value)
    {
        audioMixer.SetFloat(effectsVolume, value);
    }

    public void setDialogueVolume(float value)
    {
        audioMixer.SetFloat(dialogueVolume, value);
    }


}

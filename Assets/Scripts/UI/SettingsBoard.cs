using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using System.IO;

public class SettingsBoard : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Header("Sliders")]
    const string globalVolume = "GlobalVolume";
    const float globalMax = 1;
    const float globalMin = 0.05f;
    public Slider globalSlider;

    const string musicVolume = "MusicVolume";
    const float musicMax = 1;
    const float musicMin = 0.05f;
    public Slider musicSlider;

    const string effectsVolume = "EffectsVolume";
    const float effectsMax = 1;
    const float effectsMin = 0.05f;
    public Slider effectsSlider;

    const string dialogueVolume = "DialogueVolume";
    const float dialogueMax = 1;
    const float dialogueMin = 0.05f;
    public Slider dialogueSlider;

    int currentLanguage = 0;

    string savePath;

    public void Awake()
    {
        savePath = Application.persistentDataPath + "/Settings.data";
    }

    public void Start()
    {
        SetSliders();
    }

    void SetSliders()
    {

        globalSlider.minValue = globalMin;
        globalSlider.maxValue = globalMax;
        globalSlider.value = globalMax;

        musicSlider.minValue = musicMin;
        musicSlider.maxValue = musicMax;
        musicSlider.value = musicMax;

        effectsSlider.minValue = effectsMin;
        effectsSlider.maxValue = effectsMax;
        effectsSlider.value = effectsMax;

        dialogueSlider.minValue = dialogueMin;
        dialogueSlider.maxValue = dialogueMax;
        dialogueSlider.value = dialogueMax;

    }

    public void SetGlobalVolume(float value)
    {
        audioMixer.SetFloat(globalVolume, Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(musicVolume, Mathf.Log10(value) * 20);
    }

    public void SetEffectsVolume(float value)
    {
        audioMixer.SetFloat(effectsVolume, Mathf.Log10(value) * 20);
    }

    public void SetDialogueVolume(float value)
    {
        audioMixer.SetFloat(dialogueVolume, Mathf.Log10(value) * 20);
    }

    public void NextLanguage() {
        int languagesLength = Enum.GetNames(typeof(GlobalSettings.Languages)).Length;

        currentLanguage++;

        if (currentLanguage == languagesLength) {
            currentLanguage = 0;
        }

        switch (currentLanguage) {
            case 0:
                GlobalSettings.selectedLanguage = GlobalSettings.Languages.English;
                break;
            case 1:
                GlobalSettings.selectedLanguage = GlobalSettings.Languages.Spanish;
                break;
        
        }

        GlobalSettings.UpdateUILanguage();
    }

    /*
    void saveSettings()
    {
        SettingsSaveData saveData = new SettingsSaveData();
        
        saveData.globalVolumeValue = globalSlider.value;
        saveData.effectsVolumeValue = effectsSlider.value;
        saveData.musicVolumeValue = musicSlider.value;
        saveData.dialogueVolumeValue = dialogueSlider.value;

        string textObject = JsonUtility.ToJson(saveData);
        try
        {
            File.WriteAllText(savePath, textObject);

            Debug.Log(savePath + " file created!");
        }
        catch
        {
            Debug.LogWarning(savePath + " does not exit!");
        }


    }

    void loadSettings()
    {
        try
        {
            string readData = File.ReadAllText(savePath);
            SettingsSaveData saveData = JsonUtility.FromJson<SettingsSaveData>(readData);

            if (saveData != null)
            {

                audioMixer.SetFloat(globalVolume, saveData.globalVolumeValue);
                audioMixer.SetFloat(musicVolume, saveData.musicVolumeValue);
                audioMixer.SetFloat(effectsVolume, saveData.effectsVolumeValue);
                audioMixer.SetFloat(dialogueVolume, saveData.dialogueVolumeValue);

                setSliders();

                Debug.Log(":D");

            }

        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());

            saveSettings();
        };

    }

    class SettingsSaveData
    {
        public float globalVolumeValue;
        public float effectsVolumeValue;
        public float musicVolumeValue;
        public float dialogueVolumeValue;

    }
    */

}

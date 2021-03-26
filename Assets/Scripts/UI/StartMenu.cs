using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : InputComponent
{

    [Header("Layers")]
    public CanvasGroup firstLayerGroup;
    public CanvasGroup settingsGroup;

    float volumeValue;

    const float maxAlpha = 1;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        displayFirstLayer();
    }

    public void displaySettings()
    {
        showSettings();

        hideFirstLayerButtons();
    }

    public void displayFirstLayer()
    {
        showFirstLayerButtons();

        hideSettings();

    }

    void showSettings()
    {

        if (settingsGroup != null)
        {
            settingsGroup.alpha = 1;
            settingsGroup.blocksRaycasts = true;
        }

    }

    void hideSettings()
    {

        if (settingsGroup != null)
        {
            settingsGroup.alpha = 0;
            settingsGroup.blocksRaycasts = false;
        }


    }

    void hideFirstLayerButtons()
    {

        if (firstLayerGroup != null)
        {
            firstLayerGroup.alpha = 0;
            firstLayerGroup.blocksRaycasts = false;
        }
    }

    void showFirstLayerButtons()
    {

        if (firstLayerGroup != null)
        {
            firstLayerGroup.alpha = 1;
            firstLayerGroup.blocksRaycasts = true;
        }
    }

    public void saveSettings()
    {

    }

    public void setVolume(float value)
    {
        volumeValue = value;
    }

    public override void setInput(NormalInput inputs)
    {
    }

    public void exitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

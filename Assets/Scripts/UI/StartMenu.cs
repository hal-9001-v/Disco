using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : InputComponent
{

    [Header("Buttons")]
    public Button continueButton;

    [Header("Layers")]
    public CanvasGroup firstLayerGroup;
    public CanvasGroup settingsGroup;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        int i = LevelSaveManager.getSaveSceneIndex();

        if (i == -1)
        {
            continueButton.interactable = false;

            var color = continueButton.image.color;
            color.a = 0.3f;

            continueButton.image.color = color;

        }



        DisplayFirstLayer();
    }

    public void DisplaySettings()
    {
        ShowSettings();

        HideFirstLayerButtons();
    }

    public void DisplayFirstLayer()
    {
        ShowFirstLayerButtons();

        HideSettings();

    }

    void ShowSettings()
    {

        if (settingsGroup != null)
        {
            settingsGroup.alpha = 1;
            settingsGroup.blocksRaycasts = true;
        }

    }

    void HideSettings()
    {

        if (settingsGroup != null)
        {
            settingsGroup.alpha = 0;
            settingsGroup.blocksRaycasts = false;
        }


    }

    void HideFirstLayerButtons()
    {

        if (firstLayerGroup != null)
        {
            firstLayerGroup.alpha = 0;
            firstLayerGroup.blocksRaycasts = false;
        }
    }

    void ShowFirstLayerButtons()
    {

        if (firstLayerGroup != null)
        {
            firstLayerGroup.alpha = 1;
            firstLayerGroup.blocksRaycasts = true;
        }
    }

    public override void SetInput(NormalInput inputs)
    {
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

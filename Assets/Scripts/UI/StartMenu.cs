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

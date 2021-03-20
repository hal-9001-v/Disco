using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : InputComponent
{
    public static bool isPaused { private set; get; }
    bool canSwitchPause = true;
    public CanvasGroup myGroup;

    [Header("Layers")]
    public CanvasGroup pauseGroup;
    public CanvasGroup settingsGroup;

    float volumeValue;




    const float maxAlpha = 1;

    private void Start()
    {
        resumeGame();
    }

    public void switchPause()
    {
        if (canSwitchPause) {
            if (isPaused)
                resumeGame();
            else
                pauseGame();
        }
        
    }

    public void pauseGame()
    {
        isPaused = true;

        Time.timeScale = 0;

        if (myGroup != null)
        {
            myGroup.alpha = maxAlpha;
            myGroup.blocksRaycasts = true;


        }

        displayPauseButtons();

    }

    public void resumeGame()
    {
        isPaused = false;

        Time.timeScale = 1;

        if (myGroup != null)
        {
            myGroup.alpha = 0;
            myGroup.blocksRaycasts = false;
        }

    }

    public void displaySettings()
    {
        canSwitchPause = false;

        showSettings();

        hidePauseButtons();
    }

    public void displayPauseButtons()
    {
        canSwitchPause = true;

        showPauseButtons();

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

    void hidePauseButtons()
    {

        if (pauseGroup != null)
        {
            pauseGroup.alpha = 0;
            pauseGroup.blocksRaycasts = false;
        }
    }

    void showPauseButtons()
    {

        if (pauseGroup != null)
        {
            pauseGroup.alpha = 1;
            pauseGroup.blocksRaycasts = true;
        }
    }

    public void saveSettings() { 
        
    }

    public void setVolume(float value) {
        volumeValue = value;
    }

    public override void setInput(NormalInput inputs)
    {
        inputs.Map.Pause.performed += ctx =>
        {
            switchPause();

        };
    }
}

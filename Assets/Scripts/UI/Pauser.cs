using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : InputComponent, IPauseSubject
{
    public static bool isPaused { private set; get; }
    bool canSwitchPause = true;
    public CanvasGroup myGroup;

    [Header("Layers")]
    public CanvasGroup pauseGroup;
    public CanvasGroup settingsGroup;

    float volumeValue;

    const float maxAlpha = 1;

    Action _pauseGameAction;
    Action _resumeGameAction;

    private void Start()
    {
        ResumeGame();
    }

    public void SetCanSwitchPause(Component o,bool b) {

        //Don't let player open Pause when a new scene is being loaded
        if (o.GetType() == typeof(LevelLoader))
        {
            canSwitchPause = b;
        }
        else {
            Debug.Log(o.name + " is trying to access Pauser, but it has no permission!");
        }
        
        
    }

    public void SwitchPause()
    {
        if (canSwitchPause) {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
        
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isPaused = true;

        Time.timeScale = 0;

        if (myGroup != null)
        {
            myGroup.alpha = maxAlpha;
            myGroup.blocksRaycasts = true;


        }

        DisplayPauseButtons();

        NotifyPauseObservers();

    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;

        Time.timeScale = 1;

        if (myGroup != null)
        {
            myGroup.alpha = 0;
            myGroup.blocksRaycasts = false;
        }

        NotifyResumeObservers();
    }

    public void DisplaySettings()
    {
        canSwitchPause = false;

        ShowSettings();

        HidePauseButtons();
    }

    public void DisplayPauseButtons()
    {
        canSwitchPause = true;

        ShowPauseButtons();

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

    void HidePauseButtons()
    {

        if (pauseGroup != null)
        {
            pauseGroup.alpha = 0;
            pauseGroup.blocksRaycasts = false;
        }
    }

    void ShowPauseButtons()
    {

        if (pauseGroup != null)
        {
            pauseGroup.alpha = 1;
            pauseGroup.blocksRaycasts = true;
        }
    }

    public void SaveSettings() { 
        
    }

    public void SetVolume(float value) {
        volumeValue = value;
    }

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.Pause.performed += ctx =>
        {
            SwitchPause();

        };
    }

    public void AddPauseObserver(Action action)
    {
        _pauseGameAction += action;

    }

    public void AddResumeObserver(Action action)
    {
        _resumeGameAction += action;


    }

    public void NotifyPauseObservers()
    {
        _pauseGameAction.Invoke();
    }

    public void NotifyResumeObservers()
    {
        _resumeGameAction.Invoke();

    }
}

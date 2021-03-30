using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator screenAnimator;
    Pauser pauser;

    const float screenAnimationTime = 1;

    //SCENES
    const int menuSceneIndex = 0;
    const int loadingSceneIndex = 1;


    const string goInvisibleTrigger = "GoInvisible";
    const string goBlackTrigger = "GoBlack";

    private void Start()
    {
        pauser = FindObjectOfType<Pauser>();

        //Every scene must have a LevelLoader. Call UILanguage every time a new scene is loaded
        GlobalSettings.updateUILanguage();

        setSceneFromSaveData();
    }

    public void goToNextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void goToScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    public void goToMenu()
    {
        StartCoroutine(LoadScene(menuSceneIndex));
    }

    public void saveGame()
    {
        LevelSaveManager.saveLevelData();
    }

    public bool canContinueGame()
    {

        int index = LevelSaveManager.getSaveSceneIndex();

        if (index != -1)
            return true;
        else
            return false;

    }

    public void continueGame()
    {
        int index = LevelSaveManager.getSaveSceneIndex();

        if (index == -1)
        {
            Debug.Log("No scene to Continue!");
            return;
        }

        GlobalSettings.loadFromData = true;

        goToScene(index);

    }

    IEnumerator LoadScene(int scene)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (pauser != null)
            pauser.setCanSwitchPause(this, false);

        if (scene == loadingSceneIndex)
        {
            GlobalSettings.currentScene = scene + 1;
        }
        else
        {
            GlobalSettings.currentScene = scene;
        }

        //Screen Animation
        if (screenAnimator != null)
            screenAnimator.SetTrigger(goBlackTrigger);

        //Wait for Screen Animation
        yield return new WaitForSeconds(screenAnimationTime * 1.5f);

        SceneManager.LoadScene(loadingSceneIndex);

    }


    void setSceneFromSaveData()
    {
        int index = LevelSaveManager.getSaveSceneIndex();

        if (index == SceneManager.GetActiveScene().buildIndex)
        {
            Debug.Log("LEVEL LOADER: Setting Scene" + SceneManager.GetActiveScene().name + " from Data!");
            LevelSaveManager.setLevelFromData();
        }
    }

}

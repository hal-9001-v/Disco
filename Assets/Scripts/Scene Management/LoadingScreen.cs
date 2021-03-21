using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    const float timeUntilStartLoading = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene() {

        yield return new WaitForSeconds(timeUntilStartLoading);

        var operation = SceneManager.LoadSceneAsync(GlobalSettings.currentScene);

        Debug.Log("Start Loading scene " + SceneManager.GetSceneByBuildIndex(GlobalSettings.currentScene)+"!");

        while (!operation.isDone) {
            Debug.Log("Loading: " + operation.progress*100 + "%");
            yield return null;
        }

        Debug.Log("Scene " + SceneManager.GetSceneByBuildIndex(GlobalSettings.currentScene).name +" loaded!");


    }
}

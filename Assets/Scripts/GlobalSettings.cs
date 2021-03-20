using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{

    public enum Language
    {
        English,
        Spanish
    };

    static GlobalSettings instance;

    public static Language selectedLanguage = Language.English;

    public static int currentScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //Set on root level, so DontDestroyOnLoad can work
            transform.parent = null;

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }


    }

}

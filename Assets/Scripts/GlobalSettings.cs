using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{

    public enum Language { 
        English,
        Spanish
    };

    static GlobalSettings instance;

    public static Language selectedLanguage = Language.English;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
        

    }

}

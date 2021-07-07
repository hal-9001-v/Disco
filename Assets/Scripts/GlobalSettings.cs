using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{

    public enum Languages
    {
        English,
        Spanish
    };

    static GlobalSettings instance;

    public static Languages selectedLanguage = Languages.English;

    public static bool isPlayerInDialogue;
    public static bool IsPlayerInFight;

    public static int currentScene;

    public static bool loadFromData;

    public static void UpdateUILanguage()
    {

        foreach (UILanguage uI in FindObjectsOfType<UILanguage>())
        {
            uI.SetLanguage(selectedLanguage);
        }
    }
}

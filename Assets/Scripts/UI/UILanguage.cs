using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UILanguage : MonoBehaviour
{
    public UITextContainer textContainer;
    TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }



    public void setLanguage(GlobalSettings.Languages language)
    {

        if (textContainer != null)
        {
            switch (language)
            {
                case GlobalSettings.Languages.English:
                    textMesh.text = textContainer.englishText;
                    break;

                case GlobalSettings.Languages.Spanish:
                    textMesh.text = textContainer.spanishText;
                    break;
            }
        }
        else {
            Debug.Log("No UITextContaine assigned in "+name+"!");
        }

    }



}

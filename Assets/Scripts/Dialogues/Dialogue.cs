using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    TextBox textBox;

    public TextContainer myLines;

    private void Start()
    {
        textBox = FindObjectOfType<TextBox>();
    }



    public void triggerDialogue() {
        if (textBox != null) {
            switch (GlobalSettings.selectedLanguage) {

                case GlobalSettings.Language.English:
                    textBox.startDialogue(myLines.englishLines);
                break;

                case GlobalSettings.Language.Spanish:
                    textBox.startDialogue(myLines.spanishLines);

                    break;

                default:
                    break;
            }
        }

            
            
    }



}

using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    TextBox textBox;

    public TextContainer myLines;

    [Space(5)]
    [Header("Settings")]
    public Transform talkingPivot;
    public UnityEvent afterText;

    public Dialogue[] nextDialogues;


    private void Start()
    {
        textBox = FindObjectOfType<TextBox>();
    }

    public string[] getLines()
    {

        string[] lines;

        switch (GlobalSettings.selectedLanguage)
        {

            case GlobalSettings.Languages.English:
                lines = myLines.englishLines;
                break;

            case GlobalSettings.Languages.Spanish:
                lines = myLines.spanishLines;
                break;

            default:
                lines = null;
                break;
        }

        return lines;

    }

    public string[] getAnswers()
    {
        string[] answers;

        switch (GlobalSettings.selectedLanguage)
        {
            case GlobalSettings.Languages.English:
                answers = myLines.englishAnswers;
                break;

            case GlobalSettings.Languages.Spanish:
                answers = myLines.spanishAnswers;
                break;

            default:
                answers = null;
                break;

        }
        return answers;

    }

    public void triggerDialogue()
    {
        if (textBox != null)
        {
            textBox.startDialogue(this);
        }

    }

    public Vector3 getBoxPosition()
    {
        Vector3 boxPosition;

        if (talkingPivot != null)
        {
            boxPosition = Camera.main.WorldToScreenPoint(talkingPivot.position);
        }
        else
        {
            Debug.LogWarning("No talking pivot in " + name + " dialogue!");
            boxPosition = Vector3.zero;
        }


        return boxPosition;
    }

    public string getDialogueName()
    {
        string dialogueName;

        switch (GlobalSettings.selectedLanguage)
        {

            case GlobalSettings.Languages.English:

                dialogueName = myLines.englishName;
                break;

            case GlobalSettings.Languages.Spanish:
                dialogueName = myLines.spanishName;
                break;

            default:
                dialogueName = "";
                break;
        }

        return dialogueName;

    }

}

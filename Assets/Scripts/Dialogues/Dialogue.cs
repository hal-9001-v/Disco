using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [Space(5)]
    [Header("Settings")]
    [SerializeField] Transform _talkingPivot;

    public UnityEvent AtStart;
    public UnityEvent AfterText;

    TextBox _textBox;

    [Header("Names")]
    public string EnglishName;
    public string SpanishName;

    [Header("Lines")]

    [TextArea(2, 30)]
    public string[] EnglishLines;

    [TextArea(2, 30)]
    public string[] SpanishLines;

    public DialogueAnswer[] Answers;

    public string[] EnglishAnswers
    {

        get
        {
            if (Answers != null)
            {
                string[] lines = new string[Answers.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = Answers[i].EnglishText;
                }

                return lines;
            }

            return null;

        }

        private set { }
    }
    public string[] SpanishAnswers
    {
        get
        {

            if (Answers != null)
            {
                string[] lines = new string[Answers.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = Answers[i].SpanishText;
                }

                return lines;
            }

            return null;

        }

        private set { }
    }

    public UnityEvent[] Actions
    {
        get
        {
            UnityEvent[] actions = new UnityEvent[EnglishAnswers.Length];

            for (int i = 0; i < Answers.Length; i++)
            {
                actions[i] = Answers[i].Actions;

                if (Answers[i].NextDialogue != null)
                {
                    actions[i].AddListener(Answers[i].NextDialogue.TriggerDialogue);
                }

            }

            return actions;
        }

    }

    [Header("Gizmos")]

    [Header("Radius")]
    [Range(0.1f, 5)]
    [SerializeField] float _radius = 5;
    [SerializeField] Color _radiusColor = Color.yellow;

    [Header("Lines")]
    [SerializeField] Color _lineColor = Color.blue;

    [Header("Text")]
    [SerializeField] Color _textColor;

    private void Awake()
    {
        _textBox = FindObjectOfType<TextBox>();
    }

    public string[] GetLines()
    {
        string[] lines;

        switch (GlobalSettings.selectedLanguage)
        {
            case GlobalSettings.Languages.English:
                lines = EnglishLines;
                break;

            case GlobalSettings.Languages.Spanish:
                lines = SpanishLines;
                break;

            default:
                lines = null;
                break;
        }

        return lines;

    }

    public string[] GetAnswersTexts()
    {
        string[] answers;

        switch (GlobalSettings.selectedLanguage)
        {
            case GlobalSettings.Languages.English:
                answers = EnglishAnswers;
                break;

            case GlobalSettings.Languages.Spanish:
                answers = SpanishAnswers;
                break;

            default:
                answers = null;
                break;

        }
        return answers;

    }

    public UnityEvent[] GetAnswersActions()
    {
        return Actions;
    }

    public void TriggerDialogue()
    {
        if (_textBox != null)
        {
            _textBox.StartDialogue(this);
        }

    }

    public Vector3 GetBoxPosition()
    {
        Vector3 boxPosition;

        if (_talkingPivot != null)
        {
            boxPosition = Camera.main.WorldToScreenPoint(_talkingPivot.position);
        }
        else
        {
            Debug.LogWarning("No talking pivot in " + name + " dialogue!");
            boxPosition = Vector3.zero;
        }


        return boxPosition;
    }

    public string GetDialogueName()
    {
        string dialogueName;

        switch (GlobalSettings.selectedLanguage)
        {

            case GlobalSettings.Languages.English:

                dialogueName = EnglishName;
                break;

            case GlobalSettings.Languages.Spanish:
                dialogueName = SpanishName;
                break;

            default:
                dialogueName = "";
                break;
        }

        return dialogueName;

    }

    private void OnDrawGizmos()
    {
        if (Answers != null)
        {
            Gizmos.color = _radiusColor;
            Gizmos.DrawWireSphere(transform.position, _radius);
            Handles.Label(transform.position, name);

            Gizmos.color = _lineColor;
            foreach (var answer in Answers)
            {
                if (answer.NextDialogue != null)
                {
                    Gizmos.DrawLine(transform.position, answer.NextDialogue.transform.position);

                    string lineLabel = answer.EnglishText;

                    Handles.color = _textColor;
                    Handles.Label(0.5f * (transform.position + answer.NextDialogue.transform.position), lineLabel);
                }
            }
        }

    }

}

[Serializable]
public struct DialogueAnswer
{
    public string EnglishText;
    public string SpanishText;

    public Dialogue NextDialogue;
    public UnityEvent Actions;

}

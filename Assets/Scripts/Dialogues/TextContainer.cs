using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "TextContainer")]
public class TextContainer : ScriptableObject
{
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
            }

            return actions;
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
}




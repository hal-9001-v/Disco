using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextContainer")]
public class TextContainer : ScriptableObject
{
    [Header("Names")]
    public string englishName;
    public string spanishName;

    [Header("Lines")]

    [TextArea(2, 30)]
    public string[] englishLines;

    [TextArea(1, 30)]
    public string[] englishAnswers;

    [TextArea(2, 30)]
    public string[] spanishLines;

    [TextArea(1, 30)]
    public string[] spanishAnswers;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextContainer")]
public class TextContainer : ScriptableObject
{
    public string englishName;

    [TextArea(2,30)]
    public string[] englishLines;

    public string spanishName;

    [TextArea(2, 30)]
    public string[] spanishLines;
    

}

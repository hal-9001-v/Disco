using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UITextContainer")]
public class UITextContainer : ScriptableObject
{
    [TextArea(2, 30)]
    public string englishText;

    [TextArea(2, 30)]
    public string spanishText;


}

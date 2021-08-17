using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "FlirtSettings")]
public class FlirtSettings : ScriptableObject
{
    [Header("Settings")]
    public FlirtAnswer[] options;
    public float neededPoints;




}
[Serializable]
public class FlirtAnswer
{
    public string englishAnswer;
    public string spanishAnswer;

    public string englishReaction;
    public string spanishReaction;

    public float points;
    public float neededCombo;

}
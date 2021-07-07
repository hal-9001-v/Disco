using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] TextAsset _song;

    RythmCommand _command;

    private void Awake()
    {
        _command = FindObjectOfType<RythmCommand>();
    }

    public void StartFight()
    {
        if (_command != null && _song != null)
        {
            Debug.Log("Starting Fight with " + name);
            _command.StartFight("^, ^,<,<,>, -5p,<,>,>,>/");
            //_command.StartFight(_song.text);


        }
    }

}

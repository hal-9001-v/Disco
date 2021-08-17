using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fighter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] TextAsset _song;
    public FlirtSettings flirtSettings;

    [SerializeField] UnityAction _successActions;
    [SerializeField] UnityAction _failureActions;

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
            _command.StartFight(this, "^,^,<,<,>, -5p,<,>,>,>,c,e/");
            //_command.StartFight(_song.text);
        }
    }

    public void Success()
    {
        if (_successActions != null)
            _successActions.Invoke();
    }

    public void Failure()
    {
        if (_failureActions != null)
            _successActions.Invoke();
    }

}

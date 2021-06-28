using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CollisionInteraction : MonoBehaviour
{

    [Header("Settings")]
    //Invoke _enterEvents only the first time?
    [SerializeField] bool _enterOnlyOnce;
    //Invoke _exitEvents only the first time?
    [SerializeField] bool _exitOnlyOnce;
    public bool ReadyForInteraction = true;

    [SerializeField] UnityEvent _enterEvents;
    [SerializeField] UnityEvent _exitEvents;


#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField]bool _debugLog;
#endif

    bool _enterDone;
    bool _exitDone;

    private void Start()
    {
        var collider = GetComponent<Collider2D>();

        if (collider != null && !collider.isTrigger)
        {
            collider.isTrigger = true;
            Debug.LogWarning("Setting Collider of " + name + " as trigger!");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ReadyForInteraction)
        {
            if (collision.GetComponent<InteractionTrigger>() != null)
            {

#if UNITY_EDITOR
                if (_debugLog)
                    Debug.Log("Entering Interaction Collision with " + name + "!");
#endif

                if (_enterDone && _enterOnlyOnce)
                {
                    return;
                }

                _enterEvents.Invoke();
                _enterDone = true;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ReadyForInteraction)
        {
            if (collision.GetComponent<InteractionTrigger>() != null)
            {

#if UNITY_EDITOR
                if (_debugLog)
                    Debug.Log("Exiting Interaction Collision with " + name + "!");
#endif

                if (_exitDone && _exitOnlyOnce)
                {
                    return;
                }
                _exitEvents.Invoke();
                _exitDone = true;
            }
        }

    }

    public CollisionInteractionData GetSaveData()
    {
        var data = new CollisionInteractionData()
        {
            Name = name,
            EnterDone = _enterDone,
            ExitDone = _exitDone,
            ReadyForInteraction = ReadyForInteraction
        };

        return data;

    }

    public void SetFromLoadData(CollisionInteractionData data)
    {
        _enterDone = data.EnterDone;
        _exitDone = data.ExitDone;
        ReadyForInteraction = data.ReadyForInteraction;
    }

}


[Serializable]
public class CollisionInteractionData
{

    public string Name;
    public bool EnterDone;
    public bool ExitDone;
    public bool ReadyForInteraction;
}


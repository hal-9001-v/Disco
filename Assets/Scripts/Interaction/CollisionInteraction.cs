using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CollisionInteraction : MonoBehaviour
{
    public UnityEvent enterEvents;

    public UnityEvent exitEvents;


    [Header("Settings")]
    public bool enterOnlyOnce;
    public bool exitOnlyOnce;
    public bool readyForInteraction = true;


#if UNITY_EDITOR
    [Header("Debug")]
    public bool debugLog;
#endif


    bool enterDone;
    bool exitDone;



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
        if (readyForInteraction)
        {
            if (collision.GetComponent<InteractionTrigger>() != null)
            {

#if UNITY_EDITOR
                if (debugLog)
                    Debug.Log("Entering Interaction Collision with " + name + "!");
#endif

                if (enterDone && enterOnlyOnce)
                {
                    return;
                }

                enterEvents.Invoke();
                enterDone = true;
            }


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (readyForInteraction)
        {
            if (collision.GetComponent<InteractionTrigger>() != null)
            {

#if UNITY_EDITOR
                if (debugLog)
                    Debug.Log("Exiting Interaction Collision with " + name + "!");
#endif

                if (exitDone && exitOnlyOnce)
                {
                    return;
                }
                exitEvents.Invoke();
                exitDone = true;
            }
        }

    }



    public CollisionInteractionData getSaveData()
    {
        var data = new CollisionInteractionData()
        {
            name = name,
            enterDone = enterDone,
            exitDone = exitDone,
            readyForInteraction = readyForInteraction
        };

        return data;

    }

    public void setFromLoadData(CollisionInteractionData data)
    {
        enterDone = data.enterDone;
        exitDone = data.exitDone;
        readyForInteraction = data.readyForInteraction;
    }

}


[Serializable]
public class CollisionInteractionData
{

    public string name;
    public bool enterDone;
    public bool exitDone;
    public bool readyForInteraction;
}


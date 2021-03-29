using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInteraction : Interactable
{
    public UnityEvent events;


    [Header("Settings")]
    public bool onlyOnce;

    public bool readyForInteraction = true;

#if UNITY_EDITOR
    [Header("Debug")]
    public bool debugLog;
#endif


    bool done;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
    }

    public override void triggerInteraction()
    {
        if (readyForInteraction)
        {
            //Debug.Log("Interaction");
            if (done && onlyOnce)
                return;

#if UNITY_EDITOR
            if (debugLog)
                Debug.Log("Starting Event Interaction with " + name + "!");
#endif

            events.Invoke();
            done = true;
        }
    }
}

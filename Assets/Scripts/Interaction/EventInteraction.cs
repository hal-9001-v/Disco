using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInteraction : Interactable
{
    public UnityEvent events;

    public bool onlyOnce;

    public bool readyForInteraction = true;

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

            events.Invoke();
            done = true;
        }
    }
}

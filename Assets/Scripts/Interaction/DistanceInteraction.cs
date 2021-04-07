using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceInteraction : MonoBehaviour
{

    [Range(0, 20)]
    public float range;

    public Color gizmosColor;

    static Transform playerTransform;

    public UnityEvent events;

    [Header("Settings")]
    public bool onlyOnce;

    public bool readyForInteraction = true;

    bool done;

#if UNITY_EDITOR
    [Header("Debug")]
    public bool debugLog;
#endif


    private void Awake()
    {
        var player = FindObjectOfType<InteractionTrigger>();

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("No player in Scene!");
        }

    }

    private void Update()
    {
        triggerEvent();
    }

    private void triggerEvent()
    {
        if (readyForInteraction && playerTransform != null)
        {
            if (Vector3.Distance(playerTransform.position, transform.position) <= range)
            {
                events.Invoke();

                if (onlyOnce)
                    enabled = false;

#if UNITY_EDITOR
                if (debugLog)
                    Debug.Log("Start Distance Interaction with " + name + "!");
#endif
            }
        }

    }

    public DistanceInteractionData getSaveData()
    {
        var data = new DistanceInteractionData()
        {
            name = name,
            done = done,
            readyForInteraction = readyForInteraction
        };

        return data;

    }

    public void setFromLoadData(DistanceInteractionData data)
    {
        done = data.done;
        readyForInteraction = data.readyForInteraction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

[Serializable]
public class DistanceInteractionData
{
    public string name;

    public bool done;
    public bool readyForInteraction;
}


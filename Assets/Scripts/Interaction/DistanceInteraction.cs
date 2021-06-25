using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceInteraction : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField]
    [Range(0, 20)] float _range;
    [SerializeField] UnityEvent events;

    [SerializeField] bool onlyOnce;

    [SerializeField] bool readyForInteraction = true;


    static Transform playerTransform;
    bool done;

#if UNITY_EDITOR
    [Header("Debug")]
    public bool debugLog;
    public Color gizmosColor;
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
            if (Vector3.Distance(playerTransform.position, transform.position) <= _range)
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
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}

[Serializable]
public class DistanceInteractionData
{
    public string name;

    public bool done;
    public bool readyForInteraction;
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInteraction : Interactable
{
    [Header("Settings")]
    [Range(0.5f, 5)]
    [SerializeField] float _range;
    [SerializeField] bool _onlyOnce;
    [SerializeField] bool _readyForInteraction = true;
    [SerializeField] UnityEvent _events;

    [Header("Gizmos")]
    [SerializeField] Color _drawColor = Color.yellow;

#if UNITY_EDITOR
    [Header("Debug")]
    public bool _debugLog;
#endif
    bool done;

    Transform _player;

    private void Awake()
    {
        var trigger = FindObjectOfType<InteractionTrigger>();

        if (trigger != null) {
            _player = trigger.transform;
        }
    }

    public override void TriggerInteraction()
    {
        if (!_readyForInteraction) return;

        //Debug.Log("Interaction");
        if (done && _onlyOnce)
            return;

        if (Vector3.Distance(_player.position, transform.position) > _range)
            return;

#if UNITY_EDITOR
        if (_debugLog)
            Debug.Log("Starting Event Interaction with " + name + "!");
#endif

        _events.Invoke();
        done = true;

    }

    public void SetReadyForInteraction(bool b)
    {
        _readyForInteraction = b;
    }

    public EventInteractionData GetSaveData()
    {


        var data = new EventInteractionData()
        {
            name = name,
            done = done,
            readyForInteraction = _readyForInteraction
        };
        return data;

    }

    public void SetFromLoadData(EventInteractionData data)
    {
        done = data.done;
        _readyForInteraction = data.readyForInteraction;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = _drawColor;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

}

[Serializable]
public class EventInteractionData
{
    public string name;
    public bool done;
    public bool readyForInteraction;
}


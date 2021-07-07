using System;
using UnityEngine;
using UnityEngine.Events;

public class DistanceInteraction : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField]
    [Range(0, 20)] float _range;

    [Tooltip("Invoke _events only the first time?")]
    [SerializeField] bool _onlyOnce;

    public bool ReadyForInteraction = true;
    [Tooltip("This event will be triggered every time InteractionTrigger is within range")]
    [SerializeField] UnityEvent _events;

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] bool _debugLog;
    [SerializeField] Color _gizmosColor;
#endif

    static Transform _playerTransform;
    bool _done;

    private void Awake()
    {
        var player = FindObjectOfType<InteractionTrigger>();

        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("No player in Scene!");
        }

    }

    private void FixedUpdate()
    {

        //Check if it can be interacted and if player is within Range
        if (ReadyForInteraction && _playerTransform != null)
        {
            if (Vector3.Distance(_playerTransform.position, transform.position) <= _range)
            {
                Interaction();

            }
        }
    }



    private void Interaction()
    {
        _events.Invoke();

        if (_onlyOnce)
            enabled = false;

#if UNITY_EDITOR
        if (_debugLog)
            Debug.Log("Start Distance Interaction with " + name + "!");
#endif
    }

    public DistanceInteractionData GetSaveData()
    {
        var data = new DistanceInteractionData()
        {
            Name = name,
            Done = _done,
            ReadyForInteraction = ReadyForInteraction
        };

        return data;

    }

    public void SetFromLoadData(DistanceInteractionData data)
    {
        _done = data.Done;
        ReadyForInteraction = data.ReadyForInteraction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}

[Serializable]
public class DistanceInteractionData
{
    public string Name;

    public bool Done;
    public bool ReadyForInteraction;
}


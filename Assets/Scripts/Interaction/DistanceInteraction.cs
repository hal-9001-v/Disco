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

    //ReadyForInteraction is related to allowing this interactable to interact on its local scheme.
    public bool ReadyForInteraction = true;

    //ActiveForInteraction makes interaction possible in global scheme.
    public bool ActiveForInteraction = true;

    [Tooltip("This event will be triggered every time InteractionTrigger is within range")]
    [SerializeField] UnityEvent _events;

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] bool _debugLog;
    [SerializeField] Color _gizmosColor;
#endif

    static Transform _player;
    bool _done;

    public bool CanInteract
    {
        get
        {
            if (!ActiveForInteraction) return false;

            if (!ReadyForInteraction) return false;

            if (_done && _onlyOnce) return false;

            //Is player within Range?
            if (_player != null && Vector2.Distance(_player.position, transform.position) > _range)
                return false;


            return true;
        }

        private set { }

    }

    private void Awake()
    {
        var player = FindObjectOfType<InteractionTrigger>();

        if (player != null)
        {
            _player = player.transform;
        }
        else
        {
            Debug.LogWarning("No player in Scene!");
        }

    }

    private void FixedUpdate()
    {
        if (CanInteract)
        {
            Interaction();
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


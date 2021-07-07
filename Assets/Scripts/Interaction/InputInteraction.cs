using System;
using UnityEngine;
using UnityEngine.Events;

public class InputInteraction : MonoBehaviour
{
    //Interaction Trigger will call TriggerInteraction() every time interaction key has been pressed. 
    [Header("References")]
    [SerializeField] SpriteRenderer _markSprite;

    [Header("Settings")]
    [Range(0.5f, 5)]
    [SerializeField] float _range;

    [Tooltip("Invoke events only the first time?")]
    [SerializeField] bool _onlyOnce;
    [SerializeField] bool _readyForInteraction = true;

    [Tooltip("This event is invoke if player is in range and Interaction key has been pressed")]
    [SerializeField] UnityEvent _events;

    [Header("Gizmos")]
    [SerializeField] Color _drawColor = Color.yellow;

#if UNITY_EDITOR
    [Header("Debug")]
    public bool _debugLog;
#endif
    bool _done;
    public bool CanInteract
    {
        get
        {
            if (!_readyForInteraction) return false;

            if (_done && _onlyOnce) return false;

            //Is player within Range?
            if (_player != null && Vector2.Distance(_player.position, transform.position) > _range)
                return false;


            return true;
        }

        private set { }

    }

    Transform _player;

    private void Awake()
    {
        var trigger = FindObjectOfType<InteractionTrigger>();

        if (trigger != null)
        {
            _player = trigger.transform;
        }
    }

    public bool TriggerInteraction()
    {
        if (!CanInteract) return false;

#if UNITY_EDITOR
        if (_debugLog)
            Debug.Log("Starting Event Interaction with " + name + "!");
#endif

        _events.Invoke();
        _done = true;

        return true;

    }

    private void FixedUpdate()
    {
        //Show mark if this interactable is can be interacted
        if (_markSprite != null)
        {
            if (CanInteract)
            {
                _markSprite.enabled = true;
            }
            else
            {
                _markSprite.enabled = false;
            }
        }

    }

    public void SetReadyForInteraction(bool b)
    {
        _readyForInteraction = b;
    }

    public InputInteractionData GetSaveData()
    {
        var data = new InputInteractionData()
        {
            Name = name,
            Done = _done,
            ReadyForInteraction = _readyForInteraction
        };
        return data;

    }

    public void SetFromLoadData(InputInteractionData data)
    {
        _done = data.Done;
        _readyForInteraction = data.ReadyForInteraction;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = _drawColor;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

}

[Serializable]
public class InputInteractionData
{
    public string Name;
    public bool Done;
    public bool ReadyForInteraction;
}


using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class CollisionInteraction : MonoBehaviour
{
    //This class Invokes _enterEvents when an InteractionTrigger triggers a collision with this GameObject. Besides, _exitEvents is invoked when exitting. 
    //CARE with colliders. They must be triggers!
    [Header("Settings")]
    [Tooltip("Invoke _enterEvents only the first time?")]
    [SerializeField] bool _enterOnlyOnce;
    [Tooltip("Invoke _exitEvents only the first time?")]
    [SerializeField] bool _exitOnlyOnce;
    //ReadyForInteraction is related to allowing this interactable to interact on its local scheme.
    public bool ReadyForInteraction = true;

    //ActiveForInteraction makes interaction possible in global scheme.
    public bool ActiveForInteraction = true;

    [Tooltip("This event is invoked when an Interaction Trigger collides with this Gameobject")]
    [SerializeField] UnityEvent _enterEvents;
    [Tooltip("This event is invoked when an Interaction Trigger gets out of collision with this Gameobject")]
    [SerializeField] UnityEvent _exitEvents;


#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] bool _debugLog;
#endif

    bool _enterDone;
    bool _exitDone;

    public bool CanInteract
    {
        get
        {
            if (!ActiveForInteraction) return false;

            if (!ReadyForInteraction) return false;

            return true;
        }

        private set { }

    }

    private void Start()
    {
        var collider = GetComponent<Collider2D>();

        if (collider != null && !collider.isTrigger)
        {
            collider.isTrigger = true;
            Debug.LogWarning("Setting Collider of " + name + " as trigger!");
        }

    }

    private void EnterInteraction()
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

    private void ExitInteraction()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanInteract)
        {
            if (collision.GetComponent<InteractionTrigger>() != null)
            {
                EnterInteraction();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CanInteract)
        {
            if (collision.GetComponent<InteractionTrigger>() != null)
            {
                ExitInteraction();
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


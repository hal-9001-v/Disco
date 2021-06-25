using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : InputComponent
{
    Interactable[] _interactables;

    // Start is called before the first frame update
    void Start()
    {
        _interactables = FindObjectsOfType<Interactable>();
    }

    void TriggerInteractableInRange()
    {
        if (CanPlayerInteract())
        {
            foreach (Interactable interactable in _interactables)
            {
                interactable.TriggerInteraction();

            }
        }
    }

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.Interaction.performed += ctx =>
        {
            TriggerInteractableInRange();
        };
    }

    bool CanPlayerInteract()
    {
        return !GlobalSettings.isPlayerInDialogue && !Pauser.isPaused;
    }


}

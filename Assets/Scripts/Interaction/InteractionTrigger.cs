using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : InputComponent
{

    InputInteraction[] _interactables;
    // Start is called before the first frame update
    void Start()
    {
        _interactables = FindObjectsOfType<InputInteraction>();
    }

    void TriggerInteractableInRange()
    {
        if (CanPlayerInteract())
        {
            foreach (InputInteraction interactable in _interactables)
            {
                if (interactable.TriggerInteraction()) {
                    return;
                }

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

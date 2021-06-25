using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : InputComponent
{

    Interactable[] interactables;
    [Header("Settings")]

    [Range(0.5f, 5)]
    public float range;

    public Color drawColor;


    // Start is called before the first frame update
    void Start()
    {
        interactables = FindObjectsOfType<Interactable>();
    }

    void TriggerInteractableInRange() {

        if (CanPlayerInteract()) {
            
            foreach (Interactable interactable in interactables)
            {
                if (Vector2.Distance(interactable.transform.position, transform.position) < range)
                {
                    interactable.TriggerInteraction();

                    return;
                }
            }
        }
        

    }
    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.Interaction.performed += ctx => {
            TriggerInteractableInRange();
        };
    }


    bool CanPlayerInteract() {
        return !GlobalSettings.isPlayerInDialogue && !Pauser.isPaused;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = drawColor;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}

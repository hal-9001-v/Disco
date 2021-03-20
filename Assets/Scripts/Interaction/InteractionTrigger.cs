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
        findInteractables();
    }


    void triggerInteractableInRange() {

        if (!Pauser.isPaused) {
            
            foreach (Interactable interactable in interactables)
            {
                if (Vector2.Distance(interactable.transform.position, transform.position) < range)
                {
                    interactable.triggerInteraction();

                    return;
                }
            }
        }
        

    }
    public override void setInput(NormalInput inputs)
    {
        inputs.Map.Interaction.performed += ctx => {
            triggerInteractableInRange();
        };
    }

    void findInteractables() {
        interactables = FindObjectsOfType<Interactable>();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = drawColor;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

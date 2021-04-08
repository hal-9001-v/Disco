using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInputDistributor : MonoBehaviour
{
    CombatInput inputMap;

    static CombatInputDistributor instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;

            inputMap = new CombatInput();
            setInput();

            inputMap.Enable();
        }

    }

    private void OnDisable()
    {
        if (inputMap != null)
            inputMap.Disable();
    }

    private void OnEnable()
    {
        if (inputMap != null)
            inputMap.Enable();
    }

    void setInput()
    {

        if (inputMap != null)
        {
            foreach (CombatInputComponent components in FindObjectsOfType<CombatInputComponent>())
            {
                components.setInput(inputMap);
            }
        }
        else
        {
            Debug.LogWarning("No CombatInput in Input");
        }

    }
}

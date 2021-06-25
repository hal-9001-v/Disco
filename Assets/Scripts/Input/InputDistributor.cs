using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDistributor : MonoBehaviour
{
    NormalInput inputMap;

    static InputDistributor instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;

            inputMap = new NormalInput();

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
            foreach (InputComponent components in FindObjectsOfType<InputComponent>())
            {
                components.SetInput(inputMap);
            }
        }
        else
        {
            Debug.LogWarning("No NormalInput in Input");
        }



    }
}

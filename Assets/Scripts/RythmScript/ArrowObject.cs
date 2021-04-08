using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public bool canBePressed;
    public ButtonScript myButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (myButton != null)
        {
            if (canBePressed && myButton.pushed)
            {

                gameObject.SetActive(false);

            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Button") {

            myButton = other.gameObject.GetComponent<ButtonScript>();
            canBePressed = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
            myButton = null;
            canBePressed = false;

        }
    }



}

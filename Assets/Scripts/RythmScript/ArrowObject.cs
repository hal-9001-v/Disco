using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public bool canBePressed;
    public ButtonScript myButton;
    Scroller _scroller;

    public Action endAction;

    // Update is called once per frame
    void Update()
    {
        if (myButton != null)
        {
            if (canBePressed && myButton.Pushed)
            {
                Score();
            }
        }
    }

    public void Initialize(Scroller scroller)
    {
        _scroller = scroller;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
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

            EndArrow();
        }
    }

    public void EndArrow()
    {
        if (endAction != null)
            endAction.Invoke();

        _scroller.Arrows.Remove(this);
        Destroy(gameObject);
    }

    public void Score()
    {
        //Give Points! and all that stuff

        EndArrow();
    }

}

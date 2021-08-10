using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowObject : MonoBehaviour
{
    public bool canBePressed;
    public ButtonScript myButton;
    Scroller _scroller;
    RawImage _rawImage;

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

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();

        _rawImage.enabled = false;
    }

    public void Initialize(Scroller scroller, Transform canvas)
    {
        _scroller = scroller;
        transform.SetParent(canvas.transform, false);

        _rawImage.enabled = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    SpriteRenderer[] _renderers;

    public void Awake()
    {
        _renderers = GetComponents<SpriteRenderer>();
    }

    public void Select()
    {

    }

    public void Deselect()
    {

    }

    public void Confirm()
    {

    }

    public void Show()
    {
        if (_renderers != null)
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = true;
            }
        }

    }

    public void Hide()
    {
        if (_renderers != null)
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = false;
            }
        }

    }

}

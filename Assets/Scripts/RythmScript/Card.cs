using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Renderer[] _renderers;

    public void Awake()
    {
        _renderers = GetComponentsInChildren<Renderer>();
    }

    public void Show()
    {
        if (_renderers != null) {
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

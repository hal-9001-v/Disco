using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator _animator;
    RawImage _rawImage;

    const string SelectedBool = "isSelected";


    public void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    public void Select()
    {
        if (_animator != null) { 
            _animator.SetBool(SelectedBool, true);
            
        }

    }

    public void Deselect()
    {
        if (_animator != null)
        {
            _animator.SetBool(SelectedBool, false);
        }
    }

    public void Confirm()
    {
        Debug.Log("CARD "+ name + " selected!");
    }

    public void Show()
    {
        /*if (_renderers != null)
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = true;
            }
        }*/

        if (_rawImage != null) {
            _rawImage.enabled = true;
        }

    }

    public void Hide()
    {
        /*
        if (_renderers != null)
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = false;
            }
        }*/

        if (_rawImage != null)
        {
            _rawImage.enabled = false;
        }

    }

}

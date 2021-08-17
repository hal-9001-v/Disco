using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator _animator;
    [SerializeField] TextMeshProUGUI _textMesh;

    RythmCommand _rythmCommand;
    RawImage _rawImage;

    float _points;

    const string SelectedBool = "isSelected";


    public void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _rythmCommand = FindObjectOfType<RythmCommand>();
    }

    public void Select()
    {
        if (_animator != null)
        {
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
        Debug.Log("CARD " + name + " selected!");

        _rythmCommand.ContinueSong();
    }

    public void Show(string text, string answer, float points)
    {
        /*if (_renderers != null)
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = true;
            }
        }*/

        _points = points;

        if (_rawImage != null)
        {
            _rawImage.enabled = true;

            _textMesh.text = text;
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

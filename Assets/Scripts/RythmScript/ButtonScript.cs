using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Color _pressedColor = Color.gray;

    private RawImage _rawImage;
    private Color _originalColor;
    public bool Pushed { get; private set; }
    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _originalColor = _rawImage.color;

    }

    public void Push()
    {

        Pushed = true;
        _rawImage.color = _pressedColor;

    }

    public void Release()
    {

        Pushed = false;
        _rawImage.color = _originalColor;

    }

    public void Display()
    {
        /*
        foreach (var sprite in _sprites)
        {
            sprite.enabled = true;
        }*/
        _rawImage.enabled = true;
    }

    public void Hide()
    {
        /*
        foreach (var sprite in _sprites)
        {
            sprite.enabled = false;
        }
        */

        _rawImage.enabled = false;
    }

}

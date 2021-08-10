using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Color _pressedColor = Color.gray;

    private SpriteRenderer[] _sprites;
    private Color _originalColor;
    public bool Pushed { get; private set; }
    private void Awake()
    {
        _sprites = GetComponentsInChildren<SpriteRenderer>();
        //_originalColor = _sprites.color;
    }

    public void Push()
    {

        Pushed = true;
        // _sprites.color = _pressedColor;

    }

    public void Release()
    {

        Pushed = false;
        // _sprites.color = _originalColor;

    }

    public void Display()
    {
        foreach (var sprite in _sprites)
        {
            sprite.enabled = true;
        }
    }

    public void Hide()
    {
        foreach (var sprite in _sprites)
        {
            sprite.enabled = false;
        }
    }

}

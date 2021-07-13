using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Color _pressedColor = Color.gray;

    private SpriteRenderer mySprite;
    private Color _originalColor;
    public bool Pushed { get; private set; }
    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
        _originalColor = mySprite.color;
    }

    public void Push() {

        Pushed = true;
        mySprite.color = _pressedColor;

    }

    public void Release() {

        Pushed = false;
        mySprite.color = _originalColor;

    }

}

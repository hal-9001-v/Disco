using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    private SpriteRenderer mySprite;
    private Color myOriginalColor;
    public bool pushed;
    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myOriginalColor = mySprite.color;
    }

    public void Push() {

        pushed = true;
        mySprite.color = Color.gray;

    }

    public void Release() {

        pushed = false;
        mySprite.color = myOriginalColor;

    }

}

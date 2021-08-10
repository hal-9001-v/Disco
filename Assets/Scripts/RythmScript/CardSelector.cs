using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : InputComponent
{
    [Header("References")]
    [SerializeField] Card[] _cards;

    public bool isDisplayed { get; private set; }

    int _cardIndex;


    private void Start()
    {
        HideCards();
    }

    void SelectCard(int index)
    {
        if (isDisplayed)
        {
            if (_cards != null && _cards.Length != 0)
            {
                _cards[_cardIndex].Deselect();

                if (index < 0)
                {
                    _cardIndex = _cards.Length - 1;
                }
                else if (index >= _cards.Length)
                {
                    _cardIndex = 0;
                }
                else
                {
                    _cardIndex = index;
                }

            }
        }
    }

    void ConfirmCard(int index)
    {
        if (isDisplayed)
        {
            if (_cards != null && _cards.Length != 0)
            {
                _cards[index].Confirm();
            }
        }

    }

    public void DisplayCards()
    {
        if (_cards != null)
        {
            isDisplayed = true;

            foreach (var card in _cards)
            {
                card.Show();
            }

            SelectCard(0);
        }
    }

    public void HideCards()
    {
        if (_cards != null)
        {
            isDisplayed = false;

            foreach (var card in _cards)
            {
                card.Hide();
            }
        }
    }

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.ChangeAnswer.performed += ctx =>
        {
            float axisInput = ctx.ReadValue<float>();

            if (axisInput < 0)
            {
                SelectCard(_cardIndex - 1);
            }
            else if (axisInput > 0)
            {
                SelectCard(_cardIndex + 1);
            }


        };

        inputs.Map.ConfirmAnswer.performed += ctx =>
        {
            ConfirmCard(_cardIndex);
        };

    }

}

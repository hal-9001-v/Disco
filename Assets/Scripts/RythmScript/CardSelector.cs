using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : InputComponent
{
    [Header("References")]
    //[SerializeField] Card[] _cards;

    [SerializeField] Card _upCard;
    [SerializeField] Card _downCard;
    [SerializeField] Card _rightCard;
    [SerializeField] Card _leftCard;

    Card _selectedCard;

    public bool isDisplayed { get; private set; }

    int _cardIndex;


    private void Start()
    {
        HideCards();
    }



    /*
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
    */
    void ConfirmCard(int index)
    {
        if (isDisplayed && _selectedCard != null)
        {
            _selectedCard.Confirm();
        }

    }

    void SelectCard(Card card)
    {
        if (isDisplayed)
        {
            if (card == _selectedCard)
            {
                _selectedCard.Confirm();
                return;
            }

            _upCard.Deselect();
            _downCard.Deselect();
            _rightCard.Deselect();
            _leftCard.Deselect();

            _selectedCard = card;
            _selectedCard.Select();
        }

    }

    public void DisplayCards()
    {
        if (!isDisplayed)
        {
            isDisplayed = true;

            if (_upCard != null)
                _upCard.Show();

            if (_downCard != null)
                _downCard.Show();

            if (_rightCard != null)
                _rightCard.Show();

            if (_leftCard != null)
                _leftCard.Show();

            _selectedCard = null;
        }


    }



    public void HideCards()
    {
        if (_upCard != null)
            _upCard.Hide();

        if (_downCard != null)
            _downCard.Hide();

        if (_rightCard != null)
            _rightCard.Hide();

        if (_leftCard != null)
            _leftCard.Hide();

    }

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.ChangeCard.performed += ctx =>
        {
            Vector2 axisInput = ctx.ReadValue<Vector2>();

            if (axisInput.x < 0)
            {
                SelectCard(_leftCard);
            }
            else if (axisInput.x > 0)
            {
                SelectCard(_rightCard);

            }
            else if (axisInput.y > 0)
            {
                SelectCard(_upCard);
            }
            else if (axisInput.y < 0)
            {
                SelectCard(_downCard);

            }


        };

        inputs.Map.ConfirmAnswer.performed += ctx =>
        {
            ConfirmCard(_cardIndex);
        };

    }

}

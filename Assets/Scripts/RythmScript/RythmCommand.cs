using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCommand : MonoBehaviour, IPauseSubject
{
    [Header("References")]
    [SerializeField] Spawner _spawner;
    [SerializeField] CardSelector _cardSelector;

    [SerializeField] ButtonScript[] _buttons;

    Action _startFightAction;
    Action _endFightAction;

    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        HideButtons();
        HideCards();

        NotifyResumeObservers();
    }

    public void DisplayCards()
    {
        if (_cardSelector != null)
        {
            _cardSelector.DisplayCards();
        }
    }

    public void HideCards()
    {
        if (_cardSelector != null)
        {
            _cardSelector.HideCards();

        }
    }

    public void DisplayButtons()
    {
        if (_buttons != null)
        {
            foreach (var button in _buttons)
            {
                button.Display();
            }

        }
    }

    public void HideButtons()
    {
        if (_buttons != null)
        {
            foreach (var button in _buttons)
            {
                button.Hide();
            }

        }
    }

    public void Show()
    {

        DisplayButtons();
        HideCards();

        NotifyPauseObservers();
    }

    public void StartFight(string song)
    {
        if (_spawner != null)
        {
            _spawner.StartPlaying(song);
        }
        Show();
    }

    public void StopFight()
    {
        if (_spawner != null)
        {

        }
    }

    public void AddPauseObserver(Action action)
    {
        _startFightAction += action;

    }

    public void AddResumeObserver(Action action)
    {
        _endFightAction += action;

    }

    public void NotifyPauseObservers()
    {
        if (_startFightAction != null)
            _startFightAction.Invoke();
    }

    public void NotifyResumeObservers()
    {
        if (_endFightAction != null)
            _endFightAction.Invoke();
    }
}
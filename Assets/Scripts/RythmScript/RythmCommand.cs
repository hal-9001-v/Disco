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

    [SerializeField] CanvasGroup _canvasGroup;

    Action _startFightAction;
    Action _endFightAction;

    public float gaugePoints;

    Fighter _currentFighter;

    private void Start()
    {
        Hide();
    }

    public void ChangeGauge(float points)
    {
        gaugePoints += points;

        if (gaugePoints < 0)
        {
            gaugePoints = 0;
        }

    }

    public void CalculateResults()
    {

        if (_currentFighter != null)
        {
            if (gaugePoints >= _currentFighter.flirtSettings.neededPoints)
            {
                _currentFighter.Success();
            }
            else
            {
                _currentFighter.Failure();
            }


        }

    }

    public void Hide()
    {
        _canvasGroup.enabled = false;
        HideButtons();
        HideCards();
        
        NotifyResumeObservers();
    }

    public void DisplayCards()
    {
        if (_cardSelector != null && _currentFighter != null)
        {
            _cardSelector.DisplayCards(_currentFighter);
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
        _canvasGroup.enabled = true;
        DisplayButtons();
        HideCards();

        NotifyPauseObservers();
    }

    public void StartFight(Fighter fighter, string song)
    {
        if (_spawner != null)
        {
            _spawner.StartPlaying(song);
            _currentFighter = fighter;

        }
        Show();
    }

    public void StopFight()
    {
        CalculateResults();

        Hide();

    }

    public void ContinueSong() {

        HideCards();
        DisplayButtons();
        _spawner.ContinueSong();
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
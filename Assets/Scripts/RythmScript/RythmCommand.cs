using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCommand : MonoBehaviour, IPauseSubject
{
    [Header("References")]
    [SerializeField] Transform _buttonsParent;
    [SerializeField] Transform _cardsParent;
    [SerializeField] Spawner _spawner;

    SpriteRenderer[] _renderers;
    Card[] _cards;

    Action _startFightAction;
    Action _endFightAction;

    private void Awake()
    {
        if (_buttonsParent == null)
        {
            _buttonsParent = transform;
        }

        _renderers = _buttonsParent.GetComponentsInChildren<SpriteRenderer>();

        if (_cardsParent == null)
        {
            _cardsParent = transform;
        }

        _cards = _cardsParent.GetComponentsInChildren<Card>();

    }
    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        if (_renderers != null)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = false;

            }
        }

        HideCards();

        NotifyResumeObservers();
    }

    public void Show()
    {
        if (_renderers != null)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = true;

            }
        }

        NotifyPauseObservers();
    }

    public void StartFight(string song)
    {
        if (_spawner != null)
        {
            _spawner.StoreSong(song);
            _spawner.StartPlaying();
            GlobalSettings.IsPlayerInFight = true;
        }
        Show();
    }

    public void StopFight() { 
        
    }

    public void DisplayCards()
    {
        foreach (var card in _cards)
        {
            card.Show();
        }
    }

    public void HideCards()
    {
        foreach (var card in _cards)
        {
            card.Hide();
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
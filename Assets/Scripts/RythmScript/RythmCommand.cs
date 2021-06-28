using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmCommand : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform _buttonsParent;
    [SerializeField] Spawner _spawner;
    SpriteRenderer[] _renderers;


    private void Awake()
    {
        if (_buttonsParent == null)
        {
            _buttonsParent = transform;
        }

        _renderers = _buttonsParent.GetComponentsInChildren<SpriteRenderer>();

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
    }


    public void StartFight()
    {
        if (_spawner != null) {
            _spawner.StartPlaying();
        }

        Show();
    }

}

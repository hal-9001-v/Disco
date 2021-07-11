using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    [Header("References")]
    [Tooltip("Parent which contains all objects of this room")]
    [SerializeField] Transform _roomObjects;
    [SerializeField] CinemachineVirtualCamera _camera;

    [Header("Settings")]
    [Tooltip("Time between each frame of fading on sprites")]
    [SerializeField] [Range(0, 1)] float _fadeTime;
    [Tooltip("Alpha change between each frame of fading on sprites")]
    [SerializeField] [Range(0, 1)] float _alphaChange;

    SpriteRenderer[] _renderers;
    Collider2D[] _colliders;

    InputInteraction[] _inputInteractions;
    DistanceInteraction[] _distanceInteractions;
    CollisionInteraction[] _collisionInteractions;

    bool _roomIsActive = true;

    Coroutine _fadeCoroutine;

    private void Awake()
    {
        if (_roomObjects != null)
        {
            _inputInteractions = _roomObjects.GetComponentsInChildren<InputInteraction>();
            _collisionInteractions = _roomObjects.GetComponentsInChildren<CollisionInteraction>();
            _distanceInteractions = _roomObjects.GetComponentsInChildren<DistanceInteraction>();
            _renderers = _roomObjects.GetComponentsInChildren<SpriteRenderer>();
            _colliders = _roomObjects.GetComponentsInChildren<Collider2D>();
        }
    }

    /// <summary>
    /// Turn visible all sprites and enable colliders and Interactables. Aswell, call all DeactivateRoom() on all other rooms.
    /// </summary>
    public void ActivateRoom()
    {
        if (_camera != null)
            _camera.enabled = true;

        _roomIsActive = true;

        foreach (var room in FindObjectsOfType<Room>())
        {
            if (room != this)
                room.DeactivateRoom();
        }

        foreach (InputInteraction input in _inputInteractions)
        {
            input.ActiveForInteraction = true;
        }

        foreach (var interaction in _distanceInteractions)
        {
            interaction.ActiveForInteraction = true;
        }

        foreach (var collision in _collisionInteractions)
        {
            collision.ActiveForInteraction = true;
        }

        foreach (var collider in _colliders)
        {
            collider.enabled = true;
        }

        TurnSpritesVisible();

    }


    /// <summary>
    /// Turn Invisible all sprites and disable colliders and Interactables
    /// </summary>
    public void DeactivateRoom()
    {
        if (_camera != null)
            _camera.enabled = false;

        _roomIsActive = false;

        foreach (InputInteraction input in _inputInteractions)
        {
            input.ActiveForInteraction = false;
        }

        foreach (var interaction in _distanceInteractions)
        {
            interaction.ActiveForInteraction = false;
        }

        foreach (var collision in _collisionInteractions)
        {
            collision.ActiveForInteraction = false;
        }

        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }

        TurnSpritesInvisible();
    }

    public void SwitchInteraction()
    {

        if (_roomIsActive)
        {
            DeactivateRoom();
        }
        else
        {
            ActivateRoom();
        }

    }

    public void TurnSpritesVisible()
    {

        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(TurnVisible(_alphaChange, _fadeTime));
    }

    public void TurnSpritesInvisible()
    {

        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(TurnInvisible(_alphaChange, _fadeTime));
    }

    IEnumerator TurnInvisible(float change, float sleepTime)
    {

        float value = 1;

        while (value > 0)
        {
            foreach (var renderer in _renderers)
            {
                var color = renderer.color;
                color.a = value;
                renderer.color = color;
            }

            value -= change;


            yield return new WaitForSeconds(sleepTime);

        }

        foreach (var renderer in _renderers)
        {
            var color = renderer.color;
            color.a = 0;
            renderer.color = color;
        }
    }

    IEnumerator TurnVisible(float change, float sleepTime)
    {
        float value = 0;

        while (value < 1)
        {
            foreach (var renderer in _renderers)
            {
                var color = renderer.color;
                color.a = value;
                renderer.color = color;
            }

            value += change;


            yield return new WaitForSeconds(sleepTime);

        }

        foreach (var renderer in _renderers)
        {
            var color = renderer.color;
            color.a = 1;
            renderer.color = color;
        }




    }

}

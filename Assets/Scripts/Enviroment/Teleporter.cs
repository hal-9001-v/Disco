using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //This class will move the InteractionTrigger(the player) between _locationA and _locationB
    [Header("References")]
    [Tooltip("Move Player to this location with MovePlayerToA()")]
    [SerializeField] Transform _locationA;
    [Tooltip("Move Player to this location with MovePlayerToB()")]
    [SerializeField] Transform _locationB;

    Transform _player;

    // Start is called before the first frame update
    void Awake()
    {
        var player = FindObjectOfType<InteractionTrigger>();

        if (player != null) {
            _player = player.transform;
        }
    }

    public void MovePlayerToA()
    {
        Debug.Log("To A");
        if (_player != null)
        {

            if (_locationA != null)
            {
                _player.position = _locationA.position;

            }
            else
            {
                Debug.LogWarning("No location A in Teleporter "+name);
            }
        }
    }

    public void MovePlayerToB()
    {
        Debug.Log("To B");
        if (_player != null)
        {

            if (_locationB != null)
            {
                _player.position = _locationB.position;

            }
            else
            {
                Debug.LogWarning("No location B in Teleporter "+name);
            }
        }
    }


}

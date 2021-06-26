using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [Header("References")]
    [SerializeField] Transform _locationA;
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

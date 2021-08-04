using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [Header("Gizmos")]
    [SerializeField] Vector3 _gizmosOffset;
    [SerializeField] [Range(0, 10)] float _gizmosSize;
    [SerializeField] Color _gizmosColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterMovement>();

        if (player != null)
        {
            player.EnterStairs(transform.right);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var player = other.GetComponent<CharacterMovement>();

        if (player != null)
        {
            player.ExitStairs();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawLine(transform.position + _gizmosOffset, transform.position + _gizmosOffset + transform.right * _gizmosSize);
    }

}

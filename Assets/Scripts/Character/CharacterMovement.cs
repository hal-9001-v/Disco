using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterMovement : InputComponent
{
    [Header("Objects")]
    [SerializeField] Rigidbody2D _rigid_body;
    [SerializeField] Transform _groundPivot;
    [SerializeField] AnimatorCommand _animatorCommand;

    [Header("Settings")]
    [Range(1f, 50f)] public float velocity;
    [Range(1f, 100f)] public float jumpHeight;
    [Range(0f, 1f)] [SerializeField] float _groundRadius;

    public LayerMask GroundLayer;

    private bool facingRight = false;

    void OnDrawGizmos()
    {
        if (_groundPivot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundPivot.position, _groundRadius);
        }
    }

    private void Start()
    {
        if (_animatorCommand != null)
            _animatorCommand.Idle();
    }

    private void ApplyMovement(Vector2 movementReadValue)
    {
        if (CanPlayerMove())
        {
            if (_animatorCommand != null)
                _animatorCommand.Run();

            Vector2 newVelocity = new Vector2(0, 0);

            if (movementReadValue.x > 0)
            {
                newVelocity.x = velocity;
                FlipCharacter(true);
            }
            else if (movementReadValue.x < 0)
            {
                newVelocity.x = -velocity;
                FlipCharacter(false);
            }

            newVelocity.y = _rigid_body.velocity.y;
            _rigid_body.velocity = newVelocity;
        }
    }

    private void StopMovement()
    {
        if (CanPlayerMove())
        {
            if (_animatorCommand != null)
                _animatorCommand.Idle();

            _rigid_body.velocity = new Vector2(0, _rigid_body.velocity.y);
        }
    }

    private void Jump()
    {
        if (CanPlayerMove())
        {

            Collider2D[] groundColliders =
                Physics2D.OverlapCircleAll(_groundPivot.position, _groundRadius, GroundLayer);

            for (int i = 0; i < groundColliders.Length; i++)
            {
                if (groundColliders[i].gameObject != gameObject)
                {
                    _rigid_body.velocity = new Vector2(_rigid_body.velocity.x,
                        Mathf.Pow(jumpHeight * 2 * _rigid_body.gravityScale, 0.5f));

                    _animatorCommand.Jump();
                }
            }
        }
    }

    void FlipCharacter(bool flipRight)
    {
        if (flipRight != facingRight)
        {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = flipRight;
        }
    }

    bool CanPlayerMove()
    {
        return !Pauser.isPaused && !GlobalSettings.isPlayerInDialogue;
    }

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.Movement.performed += ctx =>
        {
            Vector2 movementReadValue = ctx.ReadValue<Vector2>();
            ApplyMovement(movementReadValue);
        };

        inputs.Map.Movement.canceled += ctx => { StopMovement(); };

        inputs.Map.Jump.performed += ctx => { Jump(); };
    }
}
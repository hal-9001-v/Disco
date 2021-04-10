using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Movement : InputComponent
{
    public Rigidbody2D rigid_body;
    [Range(1f, 50f)] public float velocity;
    [Range(1f, 100f)] public float jumpHeight;
    [Range(0f, 0.25f)] public float groundRadius;
    public Transform groundPivot;
    public LayerMask groundLayer;

    private bool facingRight = false;

    void OnDrawGizmos()
    {
        if (groundPivot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundPivot.position, groundRadius);
        }
    }

    private void ApplyMovement(Vector2 movementReadValue)
    {
        if (!Pauser.isPaused)
        {
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

            newVelocity.y = rigid_body.velocity.y;
            rigid_body.velocity = newVelocity;
        }
    }

    private void StopMovement()
    {
        if (!Pauser.isPaused)
        {
            rigid_body.velocity = new Vector2(0, rigid_body.velocity.y);
        }
    }

    private void Jump()
    {
        if (!Pauser.isPaused)
        {
            Collider2D[] groundColliders =
                Physics2D.OverlapCircleAll(groundPivot.position, groundRadius, groundLayer);

            for (int i = 0; i < groundColliders.Length; i++)
            {
                if (groundColliders[i].gameObject != gameObject)
                {
                    rigid_body.velocity = new Vector2(rigid_body.velocity.x,
                        Mathf.Pow(jumpHeight * 2 * rigid_body.gravityScale, 0.5f));
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

    public override void setInput(NormalInput inputs)
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
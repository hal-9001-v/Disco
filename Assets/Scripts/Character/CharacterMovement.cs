using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CharacterMovement : InputComponent, IPauseObserver
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

    Vector2 _movementInput;

    //"Logic" bool for movement. This bool is set automatically, when dialogue and pause occur(player will never move under these circumstances). To force a lock, use LockMovement  and SetLockMovement().
    bool _playerCanMove;

    [Tooltip("Lock for cutscenes, with use of UnityEvents for example")]
    [SerializeField] bool LockMovement;

    private void Awake()
    {
        InitializeObserver();
    }

    private void Start()
    {
        if (_animatorCommand != null)
            _animatorCommand.Idle();

    }

    //Setter for UnityEvents on Scene
    public void SetLockMovement(bool b)
    {
        LockMovement = b;

        //Make sure player stops moving and animation is Idle in case it stops.
        if (b == false)
        {
            StopMovement();
        }
    }

    private void FixedUpdate()
    {
        if (_playerCanMove && !LockMovement)
        {
            if (_movementInput != Vector2.zero)
            {
                ApplyMovement(_movementInput);
            }
            else
            {
                StopMovement();
            }
        }
    }

    private void ApplyMovement(Vector2 movementReadValue)
    {

        if (_animatorCommand != null)
            _animatorCommand.Run();

        Vector2 newVelocity = new Vector2(0, 0);

        if (movementReadValue.x > 0)
        {
            newVelocity.x = velocity;
            _animatorCommand.Flip(true);
        }
        else if (movementReadValue.x < 0)
        {
            newVelocity.x = -velocity;
            _animatorCommand.Flip(false);
        }

        newVelocity.y = _rigid_body.velocity.y;
        _rigid_body.velocity = newVelocity;
    }

    private void StopMovement()
    {
        if (_animatorCommand != null)
            _animatorCommand.Idle();

        _rigid_body.velocity = new Vector2(0, _rigid_body.velocity.y);

    }

    private void Jump()
    {
        if (_playerCanMove)
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

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.Movement.performed += ctx =>
        {
            _movementInput = ctx.ReadValue<Vector2>();

        };

        inputs.Map.Movement.canceled += ctx =>
        {
            _movementInput = Vector2.zero;
        };

        inputs.Map.Jump.performed += ctx => { Jump(); };
    }

    public void OnPauseGame()
    {
        _playerCanMove = false;

    }

    public void OnResumeGame()
    {
        _playerCanMove = true;
    }

    public void InitializeObserver()
    {
        var pauser = FindObjectOfType<Pauser>();

        if (pauser != null)
        {
            pauser.AddPauseObserver(OnPauseGame);
            pauser.AddResumeObserver(OnResumeGame);
        }

        var textBox = FindObjectOfType<TextBox>();
        if (textBox != null)
        {
            textBox.AddPauseObserver(OnPauseGame);
            textBox.AddResumeObserver(OnResumeGame);
        }


    }

    void OnDrawGizmos()
    {
        if (_groundPivot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundPivot.position, _groundRadius);
        }
    }

}
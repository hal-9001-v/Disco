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
    [Range(1f, 50f)] public float speed;
    [Range(1f, 100f)] public float jumpHeight;
    [Range(0f, 1f)] [SerializeField] float _groundRadius;

    public LayerMask GroundLayer;

    Vector2 _movementInput;

    public bool isOnStairs { get; private set; }
    Vector3 _stairsRight;

    //"Logic" bool for movement. This bool is set automatically, when dialogue and pause occur(player will never move under these circumstances). To force a lock, use LockMovement  and SetLockMovement().
    bool _playerCanMove;

    [Tooltip("Lock for cutscenes, with use of UnityEvents for example")]
    int _lockMovementCount;

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
    public void LockMovement()
    {
        _lockMovementCount++;

        //Make sure player stops moving and animation is Idle in case it stops.
        if (_lockMovementCount == 1)
        {
            StopMovement();
        }
    }

    public void FreeMovement()
    {
        _lockMovementCount--;

        if (_lockMovementCount < 0)
        {
            _lockMovementCount = 0;
        }
    }

    public void EnterStairs(Vector3 rightDirection)
    {
        isOnStairs = true;
        _stairsRight = rightDirection;
    }

    public void ExitStairs()
    {
        isOnStairs = false;
    }

    private void FixedUpdate()
    {
        if (_playerCanMove && _lockMovementCount == 0)
        {
            if (_movementInput != Vector2.zero)
            {
                if (isOnStairs)
                {
                    ApplyMovement(_movementInput, _stairsRight);
                }
                else
                {
                    ApplyMovement(_movementInput, Vector2.right);
                }
            }
            else
            {
                StopMovement();
            }
        }
    }

    private void ApplyMovement(Vector2 movementReadValue, Vector2 right)
    {

        if (_animatorCommand != null)
            _animatorCommand.Run();

        Vector2 newVelocity = Vector2.zero;

        if (movementReadValue.x > 0)
        {
            newVelocity = right * speed;
            _animatorCommand.Flip(true);
        }
        else if (movementReadValue.x < 0)
        {
            newVelocity = -right * speed;
            _animatorCommand.Flip(false);
        }

        newVelocity.y = _rigid_body.velocity.y;
        _rigid_body.AddForce(newVelocity - _rigid_body.velocity, ForceMode2D.Impulse);
        //_rigid_body.velocity = newVelocity;
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

        var rythmCommand = FindObjectOfType<RythmCommand>();
        if (rythmCommand != null)
        {
            rythmCommand.AddPauseObserver(OnPauseGame);
            rythmCommand.AddResumeObserver(OnResumeGame);
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
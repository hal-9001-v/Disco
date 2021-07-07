using UnityEngine;

public class AnimatorCommand : MonoBehaviour
{
    //This class serves abstractions to animations. Include ALL animator logic for character here so it doesnt get messy overall.
    [Header("References")]
    [SerializeField] Animator _animator;

    const string _walkTrigger = "Walk";
    const string _jumpTrigger = "Jump";
    const string _idleTrigger = "Idle";
    const string _runTrigger = "Run";

    Vector3 _rightScale;
    Vector3 _leftScale;

    private void Awake()
    {
        if (_animator != null)
        {
            _leftScale = _animator.transform.localScale;

            _rightScale = _animator.transform.localScale;
            _rightScale.x *= -1;
        }
    }

    //Flip Gameobject with visuals
    public void Flip(bool faceRight)
    {
        if (_animator != null)
        {
            if (faceRight)
            {
                _animator.transform.localScale = _rightScale;
            }
            else
            {
                _animator.transform.localScale = _leftScale;
            }
        }
    }

    public void Walk()
    {
        if (_animator != null)
            _animator.SetTrigger(_walkTrigger);

    }

    public void Jump()
    {
        if (_animator != null)
            _animator.SetTrigger(_jumpTrigger);

    }

    public void Idle()
    {
        if (_animator != null)
            _animator.SetTrigger(_idleTrigger);

    }

    public void Run()
    {
        if (_animator != null)
            _animator.SetTrigger(_runTrigger);

    }

}

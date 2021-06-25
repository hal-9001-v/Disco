using UnityEngine;

public class AnimatorCommand : MonoBehaviour
{

    [SerializeField] Animator _myAnimator;

    const string _walkTrigger = "Walk";
    const string _jumpTrigger = "Jump";
    const string _idleTrigger = "Idle";
    const string _runTrigger = "Run";


    public void Walk()
    {
        if (_myAnimator != null)
            _myAnimator.SetTrigger(_walkTrigger);

    }

    public void Jump()
    {
        if (_myAnimator != null)
            _myAnimator.SetTrigger(_jumpTrigger);

    }

    public void Idle()
    {
        if (_myAnimator != null)
            _myAnimator.SetTrigger(_idleTrigger);

    }

    public void Run()
    {
        if (_myAnimator != null)
            _myAnimator.SetTrigger(_runTrigger);

    }

}

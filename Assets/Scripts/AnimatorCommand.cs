using UnityEngine;

public class AnimatorCommand : MonoBehaviour
{

    public Animator myAnimator;

    const string _walkTrigger = "Walk";
    const string _jumpTrigger = "Jump";
    const string _idleTrigger = "Idle";
    const string _runTrigger = "Run";

    void Start() {
        Jump();
    }
    public void Walk()
    {
        if (myAnimator != null)
            myAnimator.SetTrigger(_walkTrigger);

    }

    public void Jump()
    {
        if (myAnimator != null)
            myAnimator.SetTrigger(_jumpTrigger);

    }

    public void Idle()
    {
        if (myAnimator != null)
            myAnimator.SetTrigger(_idleTrigger);

    }

    public void Run()
    {
        if (myAnimator != null)
            myAnimator.SetTrigger(_runTrigger);

    }

}

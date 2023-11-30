using UnityEngine;

public class AnimationTriggers : StateMachineBehaviour
{
    public string stateInformation;

    private IAnimation animatorObject;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName(stateInformation))
        {
            animatorObject = animator.gameObject.GetComponentInParent<IAnimation>();

            if (animatorObject == null)
                return;

            animatorObject.OnEndAnimation();
        }
    }
}


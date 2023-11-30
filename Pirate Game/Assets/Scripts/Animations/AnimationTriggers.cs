using UnityEngine;

public class AnimationTriggers : StateMachineBehaviour
{
    public string stateInformation;

    private IAnimation animatorObject;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("animator state info" + animator.name);

        if (stateInfo.IsName(stateInformation))
        {
            Debug.Log("stateInfo " + stateInformation);

            animatorObject = animator.gameObject.GetComponentInParent<IAnimation>();

            if (animatorObject != null)
                animatorObject.OnEndAnimation();
        }
    }
}


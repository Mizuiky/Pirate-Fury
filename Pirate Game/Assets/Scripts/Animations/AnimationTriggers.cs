using UnityEngine;

public class AnimationTriggers : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("CannonBallExplosion")) {
            animator.gameObject.GetComponentInParent<IEnable>().DisableComponent();
        }
    }
}

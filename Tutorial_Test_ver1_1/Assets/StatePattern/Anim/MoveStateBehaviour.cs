using UnityEngine;

namespace StatePattern_AnimationController
{
    public class MoveStateBehaviour : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Entering Move State");
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // Move state logic
            var player = animator.GetComponent<PlayerAnimatorController>();
            if (player != null)
            {
                player.transform.Translate(Vector3.forward * Time.deltaTime);
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Exiting Move State");
        }
    }
}
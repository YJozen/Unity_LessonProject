using UnityEngine;

namespace GameNamespace.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void SetAnimationState(string state)
        {
            animator.Play(state);
        }
    }
}
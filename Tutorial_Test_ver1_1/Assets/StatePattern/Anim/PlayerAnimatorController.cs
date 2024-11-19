using UnityEngine;

namespace StatePattern_AnimationController
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("Move");
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                _animator.SetTrigger("Idle");
            }
        }
    }
}
namespace GameNamespace.Enemy
{
    using UnityEngine;
    using Blackboard;
    using BehaviourTree;

    public class Die : BTNode
    {
        private Animator animator;

        public Die(Animator animator)
        {
            this.animator = animator;
        }

        public override NodeState Execute()
        {
            Debug.Log("Die Node Running");
            animator.SetTrigger("Die");
            return NodeState.Success; // 死亡状態が処理されると成功と見なす
        }
    }
}

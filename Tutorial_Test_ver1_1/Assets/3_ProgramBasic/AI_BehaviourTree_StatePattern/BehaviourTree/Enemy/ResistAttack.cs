using UnityEngine;

namespace GameNamespace.Enemy
{
    using BehaviourTree;
    using Blackboard;

    public class ResistAttack : BTNode
    {
        private Blackboard blackboard;

        public ResistAttack(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public override NodeState Execute()
        {
            Debug.Log("Resist Attack Node Running");
            // 攻撃を続ける処理
            return NodeState.Success;
        }
    }
}

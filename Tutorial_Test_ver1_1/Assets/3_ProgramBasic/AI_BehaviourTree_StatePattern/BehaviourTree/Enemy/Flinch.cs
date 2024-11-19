using UnityEngine;

namespace GameNamespace.Enemy
{
    using BehaviourTree;
    using Blackboard;

    public class Flinch : BTNode
    {
        private Blackboard blackboard;

        public Flinch(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public override NodeState Execute()
        {
            Debug.Log("Flinch Node Running");
            // 怯む処理
            return NodeState.Success;
        }
    }
}

namespace GameNamespace.Enemy
{
    using Blackboard;
    using BehaviourTree;
    using UnityEngine;

    public class ReceiveDamage : BTNode
    {
        private Blackboard blackboard;

        public ReceiveDamage(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public override NodeState Execute()
        {
            Debug.Log("ReceiveDamage Node Running");
            bool isDamaged = blackboard.GetValue<bool>("isDamaged");

            if (isDamaged)
            {
                blackboard.SetValue("isDamaged", false); // ダメージフラグをリセット
                return NodeState.Success;
            }

            return NodeState.Failure;
        }
    }
}

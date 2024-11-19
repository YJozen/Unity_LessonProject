namespace GameNamespace.Enemy
{
    using BehaviourTree;
    using Blackboard;
    using UnityEngine;

    public class CheckDeath : BTNode
    {
        private Blackboard blackboard;

        public CheckDeath(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public override NodeState Execute()
        {
            Debug.Log("CheckDeath Node Running");
            
            bool isDead = blackboard.GetValue<bool>("isDead");
            if (isDead)
            {
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}

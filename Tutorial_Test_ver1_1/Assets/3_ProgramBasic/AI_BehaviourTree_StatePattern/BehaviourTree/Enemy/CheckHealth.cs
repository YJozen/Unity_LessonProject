namespace GameNamespace.Enemy
{
    using BehaviourTree;
    using Blackboard;
    using UnityEngine;

    public class CheckHealth : BTNode
    {
        private Blackboard blackboard;
        private float specialAttackHpThreshold;

        public CheckHealth(Blackboard blackboard, float specialAttackHpThreshold)
        {
            this.blackboard = blackboard;
            this.specialAttackHpThreshold = specialAttackHpThreshold;
        }

        public override NodeState Execute()
        {
            Debug.Log("CheckHealth Node Running");
            
            float hp = blackboard.GetValue<float>("hp");
            if (hp <= specialAttackHpThreshold)
            {
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}

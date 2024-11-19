namespace GameNamespace.Enemy
{
    using UnityEngine;
    using BehaviourTree;
    using Blackboard;

    public class Stop : BTNode
    {
        private Blackboard blackboard;
        private UnityEngine.AI.NavMeshAgent navMeshAgent;

        public Stop(Blackboard blackboard)
        {
            this.blackboard = blackboard;
            this.navMeshAgent = blackboard.GetValue<UnityEngine.AI.NavMeshAgent>("navMeshAgent");
        }

        public override NodeState Execute()
        {
            if (navMeshAgent == null)
            {
                return NodeState.Failure;
            }

            // NavMeshAgentの速度をゼロにして停止
            navMeshAgent.isStopped = true;
            navMeshAgent.velocity = Vector3.zero;

            return NodeState.Running; // 停止中
        }
    }
}

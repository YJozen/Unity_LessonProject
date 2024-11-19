

namespace GameNamespace.Enemy
{

    using UnityEngine;
    using BehaviourTree;
    using Blackboard;

    public class MoveToPlayer : BTNode
    {
        private Transform player;
        private Transform enemy;
        private float attackRange;

        public MoveToPlayer(Blackboard blackboard, Transform player, Transform enemy, float attackRange)
        {
            this.player = player;
            this.enemy = enemy;
            this.attackRange = attackRange;
        }

        public override NodeState Execute()
        {
            Debug.Log("Move to Player Node Running");

            float distance = Vector3.Distance(player.position, enemy.position);
            if (distance > attackRange)
            {
                enemy.position = Vector3.MoveTowards(enemy.position, player.position, Time.deltaTime * 3f);
                return NodeState.Running;
            }
            return NodeState.Success;
        }
    }
}

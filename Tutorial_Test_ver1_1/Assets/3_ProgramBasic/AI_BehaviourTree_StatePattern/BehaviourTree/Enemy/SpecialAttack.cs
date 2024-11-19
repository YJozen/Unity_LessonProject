

namespace GameNamespace.Enemy
{

    using UnityEngine;
    using BehaviourTree;
    using Blackboard;

    public class SpecialAttack : BTNode
    {
        private Transform player;
        private Transform enemy;
        private float specialAttackRange;

        public SpecialAttack(Blackboard blackboard, Transform player, Transform enemy, float specialAttackRange)
        {
            this.player = player;
            this.enemy = enemy;
            this.specialAttackRange = specialAttackRange;
        }

        public override NodeState Execute()
        {
            Debug.Log("Special Attack Node Running");

            float distance = Vector3.Distance(player.position, enemy.position);
            if (distance <= specialAttackRange)
            {
                Debug.Log("Performing Special Attack!");
                // Implement special attack logic here
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}


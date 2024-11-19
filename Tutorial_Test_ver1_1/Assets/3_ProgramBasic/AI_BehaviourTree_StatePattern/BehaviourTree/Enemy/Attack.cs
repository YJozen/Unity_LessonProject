

namespace GameNamespace.Enemy
{

    using UnityEngine;
    using BehaviourTree;
    using Blackboard;

    public class Attack : BTNode
    {
        private Blackboard blackboard;
        private Transform player;
        private Transform enemy;
        private float attackRange;

        public Attack(Blackboard blackboard, Transform player, Transform enemy, float attackRange)
        {
            this.blackboard = blackboard;
            this.player = player;
            this.enemy = enemy;
            this.attackRange = attackRange;
        }

        public override NodeState Execute()
        {
            Debug.Log("Attack Node Running");
            
            float distance = Vector3.Distance(player.position, enemy.position);
            if (distance <= attackRange)
            {
                Debug.Log("Performing Attack!");
                // 通常攻撃の処理を実行
                PerformAttack();
                return NodeState.Success;
            }
            return NodeState.Failure;
        }

        private void PerformAttack()
        {
            // 通常攻撃の具体的な処理をここに実装
            Debug.Log("Performing normal attack.");
        }
    }
}

using UnityEngine;

namespace GameNamespace.Enemy
{
    using BehaviourTree;
    using Blackboard;

    public class ComboAttack : BTNode
    {
        private Transform player;
        private Transform enemy;
        private float attackRange;

        public ComboAttack(Blackboard blackboard, Transform player, Transform enemy, float attackRange)
        {
            this.player = player;
            this.enemy = enemy;
            this.attackRange = attackRange;
        }

        public override NodeState Execute()
        {
            Debug.Log("Combo Attack Node Running");

            if (Vector3.Distance(enemy.position, player.position) <= attackRange)
            {
                // コンボ攻撃の処理
                // 例えばアニメーションやダメージ処理など
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}

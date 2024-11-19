namespace GameNamespace.Enemy
{
    using UnityEngine;
    using BehaviourTree;
    using Blackboard;

    public class AttackSelector : BTNode
    {
        private Blackboard blackboard;
        private Transform player;
        private Transform enemy;
        private System.Random random;

        public AttackSelector(Blackboard blackboard, Transform player, Transform enemy)
        {
            this.blackboard = blackboard;
            this.player = player;
            this.enemy = enemy;
            this.random = new System.Random();
        }

        public override NodeState Execute()
        {
            Debug.Log("AttackSelector Node Running");

            float hp = blackboard.GetValue<float>("hp");
            float specialAttackHpThreshold = blackboard.GetValue<float>("specialAttackHpThreshold");

            if (hp <= specialAttackHpThreshold)
            {
                return PerformSpecialAttack();
            }

            return PerformRandomAttack();
        }

        private NodeState PerformSpecialAttack()
        {
            Debug.Log("Performing Special Attack");
            // 特殊攻撃のロジックをここに実装
            // 特殊攻撃中は怯まない
            return NodeState.Success;
        }

        private NodeState PerformRandomAttack()
        {
            int attackChoice = random.Next(0, 3); // 0-2のランダムな値を生成

            switch (attackChoice)
            {
                case 0:
                    Debug.Log("Performing Normal Attack");
                    // 通常攻撃のロジックをここに実装
                    break;
                case 1:
                    Debug.Log("Performing Combo Attack");
                    // コンボ攻撃のロジックをここに実装
                    break;
                case 2:
                    Debug.Log("Performing Unflinching Attack");
                    // 怯まない攻撃のロジックをここに実装
                    break;
            }

            return NodeState.Success;
        }
    }
}

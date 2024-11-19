namespace GameNamespace.Enemy
{
    using UnityEngine;
    using BehaviourTree;
    using Blackboard;

    public class DetectPlayer : BTNode
    {
        // private Blackboard blackboard;
        // private Transform enemy;
        // private Transform player;
        // private float detectionRange;

        // public DetectPlayer(Blackboard blackboard, Transform enemy, Transform player, float detectionRange)
        // {
        //     this.blackboard = blackboard;
        //     this.enemy = enemy;
        //     this.player = player;
        //     this.detectionRange = detectionRange;
        // }

        // public override NodeState Execute()
        // {
        //     Debug.Log("DetectPlayer Node Running");

        //     float distance = Vector3.Distance(enemy.position, player.position);
        //     if (distance <= detectionRange)
        //     {
        //         blackboard.SetValue("playerDetected", true);
        //         return NodeState.Success;
        //     }

        //     blackboard.SetValue("playerDetected", false);
        //     return NodeState.Failure;
        // }






        // private Transform enemy;
        // private Transform player;
        // private float detectionRange;

        // public DetectPlayer(Transform enemy, Transform player, float detectionRange)
        // {
        //     this.enemy = enemy;
        //     this.player = player;
        //     this.detectionRange = detectionRange;
        // }

        // public override NodeState Execute()
        // {
        //     float distanceToPlayer = Vector3.Distance(enemy.position, player.position);

        //     if (distanceToPlayer <= detectionRange)
        //     {
        //         Debug.Log("Player detected");
        //         return NodeState.Success;
        //     }

        //     return NodeState.Failure;
        // }





        private Transform enemyTransform;
        private Transform playerTransform;
        private float detectionRange;
        private float detectionAngle;
        private LayerMask obstacleMask;

        public DetectPlayer(Transform enemyTransform, Transform playerTransform, float detectionRange, float detectionAngle, LayerMask obstacleMask)
        {
            this.enemyTransform = enemyTransform;
            this.playerTransform = playerTransform;
            this.detectionRange = detectionRange;
            this.detectionAngle = detectionAngle;
            this.obstacleMask = obstacleMask;
        }

        public override NodeState Execute()
        {
            Vector3 directionToPlayer = (playerTransform.position - enemyTransform.position).normalized;
            float distanceToPlayer = Vector3.Distance(enemyTransform.position, playerTransform.position);

            // 視野範囲にPlayerがいるかチェック
            if (distanceToPlayer < detectionRange)
            {
                float angleToPlayer = Vector3.Angle(enemyTransform.forward, directionToPlayer);
                if (angleToPlayer < detectionAngle / 2)
                {
                    // レイキャストで遮蔽物がないかチェック
                    if (!Physics.Raycast(enemyTransform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                    {
                        Debug.Log("Player Detected!");
                        return NodeState.Success;
                    }
                }
            }

            return NodeState.Failure;
        }




    }
}

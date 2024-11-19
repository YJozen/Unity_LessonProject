namespace GameNamespace.Enemy
{
    using UnityEngine;
    using UnityEngine.AI;
    using BehaviourTree;
    using Blackboard;


    public class Patrol : BTNode
    {
        // private Blackboard blackboard;
        // private NavMeshAgent navMeshAgent;
        // private Waypoint waypointManager;
        // private Transform[] waypoints;
        // private int currentWaypointIndex = 0;
        // private float waitTime = 1f; // 待機時間
        // private float waitTimer = 0f;

        // public Patrol(Blackboard blackboard, Transform enemyTransform, float patrolRange)
        // {
        //     this.blackboard = blackboard;
        //     this.navMeshAgent = blackboard.GetValue<NavMeshAgent>("navMeshAgent");
        //     this.waypointManager = enemyTransform.GetComponent<Waypoint>();
        //     this.waypoints = waypointManager.waypoints;
        // }

        // public override NodeState Execute()
        // {
        //     if (navMeshAgent == null || waypoints == null || waypoints.Length == 0)
        //     {
        //         return NodeState.Failure;
        //     }

        //     // 移動中のチェック
        //     if (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        //     {
        //         return NodeState.Running; // 移動中
        //     }

        //     // 待機タイマーの処理
        //     if (waitTimer > 0)
        //     {
        //         waitTimer -= Time.deltaTime;
        //         return NodeState.Running; // 待機中
        //     }

        //     // 次のポイントを設定
        //     navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);

        //     // 次のウェイポイントに進む
        //     currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        //     waitTimer = waitTime; // 待機タイマーをリセット

        //     return NodeState.Running;
        // }


        private NavMeshAgent agent;
        private Waypoint waypointManager;
        private int currentWaypointIndex = 0;

        public Patrol(NavMeshAgent agent, Waypoint waypointManager)
        {
            this.agent = agent;
            this.waypointManager = waypointManager;
        }

        public override NodeState Execute()
        {
            if (agent == null || waypointManager == null)
            {
                return NodeState.Failure;
            }

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                agent.SetDestination(waypointManager.GetNextWaypoint(currentWaypointIndex).position);
                currentWaypointIndex++;
            }

            return NodeState.Running;
        }

    }
}

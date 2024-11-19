using UnityEngine;
using UnityEngine.AI;

namespace DetectSample
{
    public class EnemyController_State : MonoBehaviour
    {
        public Transform player;
        public float viewRadius = 10f;
        public float viewAngle = 45f;
        public LayerMask playerMask;
        public LayerMask obstacleMask{ get; set; }
        public NavMeshAgent agent;

        public Transform[] patrolPoints;
        public float searchDuration = 5f;
        public float restDuration = 2f;

        public Vector3 lastKnownPosition { get; set; }
        public bool isSearching { get; set; } = false;
        public float searchTimer { get; set; } = 0f;
        public bool isResting { get; set; } = false;
        public float restTimer { get; set; } = 0f;

        private State currentState;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            ChangeState(new PatrolState(this));
        }

        void Update()
        {
            currentState.UpdateState();
        }

        public void ChangeState(State newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }
            currentState = newState;
            currentState.EnterState();
        }

        public bool IsPlayerInSight()
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer < viewRadius)
            {
                if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
                {
                    if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void SetDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
        }

        public bool IsAtDestination()
        {
            return !agent.pathPending && agent.remainingDistance < agent.stoppingDistance;
        }

        public void ResetVision()
        {
            viewRadius = 10f;
            viewAngle = 45f;
        }
    }
}

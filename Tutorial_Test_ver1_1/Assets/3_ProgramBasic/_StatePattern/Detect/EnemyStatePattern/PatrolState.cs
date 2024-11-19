using UnityEngine;

namespace DetectSample
{
    public class PatrolState : State
    {
        private EnemyController_State enemy;
        private int currentPatrolIndex = 0;

        public PatrolState(EnemyController_State enemy)
        {
            this.enemy = enemy;
        }

        public override void EnterState()
        {
            GoToNextPatrolPoint();
        }

        public override void UpdateState()
        {
            if (enemy.isResting)
            {
                enemy.restTimer += Time.deltaTime;
                if (enemy.restTimer >= enemy.restDuration)
                {
                    enemy.isResting = false;
                    GoToNextPatrolPoint();
                }
            }
            else if (enemy.IsAtDestination())
            {
                enemy.isResting = true;
                enemy.restTimer = 0f;
            }
        }

        public override void ExitState()
        {
            // 休憩中のフラグとタイマーをリセット
            enemy.isResting = false;
            enemy.restTimer = 0f;
        }

        private void GoToNextPatrolPoint()
        {
            if (enemy.patrolPoints.Length == 0) return;

            enemy.SetDestination(enemy.patrolPoints[currentPatrolIndex].position);
            currentPatrolIndex = (currentPatrolIndex + 1) % enemy.patrolPoints.Length;
        }
    }
}

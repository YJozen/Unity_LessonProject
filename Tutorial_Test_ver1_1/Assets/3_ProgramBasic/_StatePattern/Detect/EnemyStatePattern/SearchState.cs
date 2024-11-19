using UnityEngine;

namespace DetectSample
{
    public class SearchState : State
    {
        private EnemyController_State enemy;

        public SearchState(EnemyController_State enemy)
        {
            this.enemy = enemy;
        }

        public override void EnterState()
        {
            enemy.searchTimer = 0f;
            enemy.SetDestination(enemy.lastKnownPosition);
        }

        public override void UpdateState()
        {
            if (Vector3.Distance(enemy.transform.position, enemy.lastKnownPosition) < enemy.agent.stoppingDistance)
            {
                enemy.searchTimer += Time.deltaTime;
                if (enemy.searchTimer >= enemy.searchDuration)
                {
                    enemy.ChangeState(new PatrolState(enemy));
                }
            }
            else
            {
                enemy.SetDestination(enemy.lastKnownPosition);
            }
        }

        public override void ExitState()
        {
            // 探索中のフラグとタイマーをリセット
            enemy.isSearching = false;
            enemy.searchTimer = 0f;
        }
    }
}

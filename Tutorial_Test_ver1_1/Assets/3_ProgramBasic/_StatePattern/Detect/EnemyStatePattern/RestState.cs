using UnityEngine;

namespace DetectSample
{
    public class RestState : State
    {
        private EnemyController_State enemy;

        public RestState(EnemyController_State enemy)
        {
            this.enemy = enemy;
        }

        public override void EnterState()
        {
            enemy.restTimer = 0f;
        }

        public override void UpdateState()
        {
            enemy.restTimer += Time.deltaTime;
            if (enemy.restTimer >= enemy.restDuration)
            {
                enemy.ChangeState(new PatrolState(enemy));
            }
        }

        public override void ExitState()
        {
            // 休憩中のフラグとタイマーをリセット
            enemy.isResting = false;
            enemy.restTimer = 0f;
        }
    }
}

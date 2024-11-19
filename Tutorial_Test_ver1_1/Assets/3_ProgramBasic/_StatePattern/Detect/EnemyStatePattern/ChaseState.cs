using UnityEngine;

namespace DetectSample
{
    public class ChaseState : State
    {
        private EnemyController_State enemy;

        public ChaseState(EnemyController_State enemy)
        {
            this.enemy = enemy;
        }

        public override void EnterState()
        {
            enemy.viewRadius *= 5f;
            enemy.viewAngle = 360f;
        }

        public override void UpdateState()
        {
            if (enemy.IsPlayerInSight())
            {
                enemy.SetDestination(enemy.player.position);
                enemy.lastKnownPosition = enemy.player.position;
            }
            else
            {
                enemy.ChangeState(new SearchState(enemy));
            }
        }

        public override void ExitState()
        {
            // 視野範囲を元に戻す
            enemy.ResetVision();
        }
    }
}

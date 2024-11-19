
using UnityEngine;

namespace StatePattern_Generic
{
    public class PlayerIdleState : State<Player>
    {
        public PlayerIdleState(Player owner) : base(owner) { }

        public override void Enter()
        {
            Debug.Log("Player Entering Idle State");
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Owner.GetComponent<Player>().ChangeState<PlayerMoveState>();
            }
        }

        public override void Exit()
        {
            Debug.Log("Player Exiting Idle State");
        }
    }
}
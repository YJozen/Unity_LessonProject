using UnityEngine;

namespace StatePattern_Generic
{
    public class PlayerMoveState : State<Player>
    {
        public PlayerMoveState(Player owner) : base(owner) { }

        public override void Enter()
        {
            Debug.Log("Player Entering Move State");
        }

        public override void Update()
        {
            Owner.transform.Translate(Vector3.forward * Time.deltaTime);

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Owner.GetComponent<Player>().ChangeState<PlayerIdleState>();
            }
        }

        public override void Exit()
        {
            Debug.Log("Player Exiting Move State");
        }
    }
}


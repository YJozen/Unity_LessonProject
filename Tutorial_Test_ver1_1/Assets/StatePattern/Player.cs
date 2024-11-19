using UnityEngine;

namespace StatePattern_Generic
{
    public class Player : MonoBehaviour
    {
        private StateMachine<Player> _stateMachine;

        void Start()
        {
            _stateMachine = new StateMachine<Player>(this);
            _stateMachine.AddState(new PlayerIdleState(this));
            _stateMachine.AddState(new PlayerMoveState(this));

            _stateMachine.ChangeState<PlayerIdleState>();
        }

        void Update()
        {
            _stateMachine.Update();
        }

        public void ChangeState<S>() where S : State<Player>
        {
            _stateMachine.ChangeState<S>();
        }
    }
}

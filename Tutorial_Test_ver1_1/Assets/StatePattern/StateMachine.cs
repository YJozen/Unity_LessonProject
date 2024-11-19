using System.Collections.Generic;

namespace StatePattern_Generic
{
    public class StateMachine<T>
    {
        private T _owner;
        private State<T> _currentState;
        private Dictionary<System.Type, State<T>> _states = new Dictionary<System.Type, State<T>>();

        public StateMachine(T owner)
        {
            _owner = owner;
        }

        public void AddState(State<T> state)
        {
            var type = state.GetType();
            if (!_states.ContainsKey(type))
            {
                _states[type] = state;
            }
        }

        public void ChangeState<S>() where S : State<T>
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            var type = typeof(S);
            if (_states.ContainsKey(type))
            {
                _currentState = _states[type];
                _currentState.Enter();
            }
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.Update();
            }
        }
    }
}


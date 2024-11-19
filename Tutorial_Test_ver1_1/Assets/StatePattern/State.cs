namespace StatePattern_Generic
{
    public abstract class State<T>
    {
        protected T Owner;

        public State(T owner)
        {
            Owner = owner;
        }

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}
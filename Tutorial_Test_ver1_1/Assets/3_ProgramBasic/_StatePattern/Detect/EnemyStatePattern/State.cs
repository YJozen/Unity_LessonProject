namespace DetectSample
{
    public abstract class State
    {
        public abstract void EnterState();
        public abstract void UpdateState();
        public virtual void ExitState() { } // ExitState メソッドを追加
    }
}
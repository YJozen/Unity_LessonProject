namespace BehaviourTree
{
    using UnityEngine;
    using Blackboard;


    public abstract class TaskNode : BTNode
    {
        protected Blackboard blackboard;

        // コンストラクタで Blackboard を受け取る
        public TaskNode(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        // 共通のログ機能
        protected void Log(string message)
        {
            Debug.Log($"{this.GetType().Name}: {message}");
        }

        // 各タスクノードで必要に応じてオーバーライド可能な初期化メソッド
        public virtual void Initialize() { }
    }
}
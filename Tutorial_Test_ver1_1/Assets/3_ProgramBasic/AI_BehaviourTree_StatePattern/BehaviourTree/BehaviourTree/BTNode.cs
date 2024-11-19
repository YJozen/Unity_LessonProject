// Behaviour Treeの基本的な要素で、行動（タスク）を定義
// すべてのノードは、この基底クラスを継承し、特定のAIアクションを実装

namespace BehaviourTree
{
    
    // public abstract class BTNode
    // {
    //     protected NodeState state;
    //     public BTNode() {}
    //     public abstract NodeState Execute();
    // }
    // public enum NodeState
    // {
    //     Running,
    //     Success,
    //     Failure
    // }

    public enum NodeState
    {
        Inactive,
        Running,
        Success,
        Failure,
        Completed
    }

    public abstract class BTNode
    {
        public NodeState State { get; private set; } = NodeState.Inactive;

        public abstract NodeState Execute();

        public void Start()
        {
            State = NodeState.Running;
            OnStart();
        }

        protected virtual void OnStart() { }

        public void End()
        {
            OnEnd();
            State = NodeState.Completed;
        }

        protected virtual void OnEnd() { }

        public void Abort()
        {
            OnAbort();
            State = NodeState.Failure;
        }

        protected virtual void OnAbort() { }
    }

}


//使用例
// namespace BehaviourTree
// {
//     public class ExampleNode : BTNode
//     {
//         protected override void OnStart()
//         {
//             Debug.Log("Node Started");
//         }

//         public override NodeState Execute()
//         {
//             Debug.Log("Node Executing");
//             // 実行中の処理
//             return NodeState.Running;
//         }

//         protected override void OnEnd()
//         {
//             Debug.Log("Node Ended");
//         }

//         protected override void OnAbort()
//         {
//             Debug.Log("Node Aborted");
//         }
//     }
// }

//使い方
//var conditionNode = new ConditionNode(() => blackboard.GetValue<float>("hp") > 50);

// ConditionNode は、条件に応じて Success や Failure を返すノードです。条件が満たされていれば Success を返し、そうでなければ Failure を返します

namespace BehaviourTree
{
    public class ConditionNode : BTNode
    {
        private System.Func<bool> condition;

        public ConditionNode(System.Func<bool> condition)
        {
            this.condition = condition;
        }

        public override NodeState Execute()
        {
            return condition() ? NodeState.Success : NodeState.Failure;
        }
    }
}

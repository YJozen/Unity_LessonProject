//Decorator ノードは、子ノードの結果を変更したり、条件を付与するために使用されます。
//たとえば、子ノードの結果を逆にする InverterDecorator や、特定の条件下でしか子ノードを実行しない ConditionDecorator などがあります。

// 使い方:
//var invertedNode = new InverterDecorator(someChildNode);

namespace BehaviourTree
{
    public abstract class Decorator : BTNode
    {
        protected BTNode child;

        public Decorator(BTNode child)
        {
            this.child = child;
        }
    }

    public class InverterDecorator : Decorator
    {
        public InverterDecorator(BTNode child) : base(child) { }

        public override NodeState Execute()
        {
            var result = child.Execute();
            if (result == NodeState.Success)
                return NodeState.Failure;
            if (result == NodeState.Failure)
                return NodeState.Success;
            return result;
        }
    }
}

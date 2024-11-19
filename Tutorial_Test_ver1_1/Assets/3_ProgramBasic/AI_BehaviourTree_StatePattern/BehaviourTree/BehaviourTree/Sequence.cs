// 複数の子ノードを順番に評価
// すべての子ノードが成功するまで処理を進めます。
// いずれかの子ノードが失敗した場合、シーケンス全体が失敗します。


//Sequenceノードの役割


//動作: 
//Sequenceノードは、子ノードを順番に実行し、全ての子ノードが成功した場合に自身も成功と判断します。
//1つでも失敗した子ノードがあれば、自身も失敗と判断します。

//使用例: 
//「かつ」の条件を実現するために使います。
//例えば、プレイヤーを見つけて、プレイヤーに近づき、攻撃するという一連の行動を順番に実行する場合に使用します。


using System.Collections.Generic;

namespace BehaviourTree
{
    public class Sequence : BTNode
    {
        private List<BTNode> children = new List<BTNode>();

        public void AddChild(BTNode node)
        {
            children.Add(node);
        }

        public override NodeState Execute()
        {
            //Sequenceノードの目的は「かつ」の条件を評価することです。
            //子ノードが順番に実行され、全ての子ノードが成功した場合にのみ成功と判断します。
            foreach (var child in children)
            {
                var state = child.Execute();
                if (state == NodeState.Failure)
                {
                    return NodeState.Failure;
                }
            }
            return NodeState.Success;
        }
    }
}

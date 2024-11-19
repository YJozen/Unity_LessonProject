// 複数の子ノードを評価し、最初に成功したノードを選択
// いずれかの子ノードが成功すればセレクター全体が成功となります。
// すべての子ノードが失敗した場合、セレクター全体が失敗します。


// Selectorノードの役割


// 動作: 
//Selectorノードは、子ノードを順番に実行し、1つでも成功した子ノードがあれば、自身も成功と判断します。
//全ての子ノードが失敗した場合にのみ、自身が失敗と判断します。

// 使用例: 
//「または」の条件を実現するために使います。
//例えば、敵がプレイヤーを見つけた場合に攻撃する、そうでなければプレイヤーに近づく、といったシナリオで使います。




using System.Collections.Generic;

namespace BehaviourTree
{
    public class Selector : BTNode
    {
        private List<BTNode> children = new List<BTNode>();

        public void AddChild(BTNode node)
        {
            children.Add(node);
        }

        public override NodeState Execute()
        {
            // Selectorノードの目的は「または」の条件を評価することです。
            //子ノードのいずれかが成功すれば、そのSelectorノードも成功と判断します。
            foreach (var child in children)
            {
                var state = child.Execute();
                if (state == NodeState.Success)
                {
                    return NodeState.Success;
                }
            }
            return NodeState.Failure;
        }
    }
}

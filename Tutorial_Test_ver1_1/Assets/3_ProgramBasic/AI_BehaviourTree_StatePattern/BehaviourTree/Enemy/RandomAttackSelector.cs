using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

namespace GameNamespace.Enemy
{
    public class RandomSelector : BTNode
    {
        private List<BTNode> children = new List<BTNode>();
        private System.Random random = new System.Random();

        public void AddChild(BTNode node)
        {
            children.Add(node);
        }

        public override NodeState Execute()
        {
            if (children.Count == 0)
                return NodeState.Failure;

            // ランダムに子ノードを選択
            int index = random.Next(children.Count);
            var selectedNode = children[index];
            
            return selectedNode.Execute();
        }
    }
}

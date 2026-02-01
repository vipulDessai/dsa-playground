using System.Collections.Generic;

namespace learning_dsa_csharp._11_graphs._002_clone_graph
{
    internal class Solution
    {
        private Dictionary<Node, Node> d = new Dictionary<Node, Node>();

        public Node CloneGraph(Node node)
        {
            if (node != null)
            {
                return Dfs(node);
            }
            else
            {
                return null;
            }
        }

        public Node Dfs(Node node)
        {
            if (d.ContainsKey(node))
            {
                return d[node];
            }

            var copy = new Node(node.val);
            d.Add(node, copy);

            foreach (var nei in node.neighbors)
            {
                copy.neighbors.Add(Dfs(nei));
            }

            return copy;
        }
    }
}

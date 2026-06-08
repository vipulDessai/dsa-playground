// [Clone Graph](https://leetcode.com/problems/clone-graph/description/)

using Utils;

namespace learning_dsa_csharp._11_graphs._001_clone_graph
{
    internal class Solution
    {
        private Dictionary<Node, Node> d = new Dictionary<Node, Node>();

        public Node CloneGraph(Node node)
        {
            if (node != null)
            {
                return dfs(node);
            }
            else
            {
                return null;
            }
        }

        public Node dfs(Node node)
        {
            if (d.ContainsKey(node))
            {
                return d[node];
            }

            var copy = new Node(node.val);
            d.Add(node, copy);

            foreach (var nei in node.neighbors)
            {
                copy.neighbors.Add(dfs(nei));
            }

            return copy;
        }
    }

    public class MySoln {
        public Node CloneGraph(Node node) {
            
        }
    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] input = [[2, 4], [1, 3], [2, 4], [1, 3]];

            var inputGraph = NodeGraph.Generate(input);

            var output = s.CloneGraph(inputGraph);

            Queue<Node> q = new();
            q.Enqueue(output);
            HashSet<int> visited = new() { 0 };
            while (q.Count > 0)
            {
                int qLen = q.Count;

                while (qLen > 0)
                {
                    var curNode = q.Dequeue();

                    Console.Write(curNode.val + " : ");

                    foreach (var nChild in curNode.neighbors)
                    {
                        if (!visited.Contains(nChild.val - 1))
                        {
                            Console.Write(nChild.val + ", ");

                            q.Enqueue(nChild);
                        }
                    }

                    visited.Add(curNode.val);
                    --qLen;

                    Console.WriteLine();
                }
            }
        }
    }
}

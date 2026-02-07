namespace learning_dsa_csharp._07_trees._006_amount_of_time_to_infect_tree
{
    internal class DFS_Graph_Hash_My_Own_Solution
    {
        Dictionary<int, List<TreeNode>> u = new Dictionary<int, List<TreeNode>>();

        private void dfsCreateUndirectedGraph(TreeNode n, TreeNode p)
        {
            if (n == null)
            {
                return;
            }
            else
            {
                List<TreeNode> l = new List<TreeNode>();

                if (p != null)
                {
                    l.Add(p);
                }
                if (n.left != null)
                {
                    l.Add(n.left);
                }
                if (n.right != null)
                {
                    l.Add(n.right);
                }

                u.Add((int)n.val, l);

                dfsCreateUndirectedGraph(n.left, n);
                dfsCreateUndirectedGraph(n.right, n);
            }
        }

        public int AmountOfTime(TreeNode root, int start)
        {
            dfsCreateUndirectedGraph(root, null);

            Queue<TreeNode> q = new Queue<TreeNode>();
            HashSet<int> m = new HashSet<int>() { start };
            var firstList = u[start];
            for (int i = 0; i < firstList.Count; ++i)
            {
                q.Enqueue(firstList[i]);
            }

            int res = 0;
            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; i++)
                {
                    TreeNode n = q.Dequeue();
                    int val = (int)n.val;
                    m.Add(val);

                    var curList = u[val];
                    for (int j = 0; j < curList.Count; ++j)
                    {
                        var curNode = curList[j];
                        if (!m.Contains((int)curNode.val))
                        {
                            q.Enqueue(curNode);
                        }
                    }
                }

                res++;
            }

            return res;
        }
    }
}

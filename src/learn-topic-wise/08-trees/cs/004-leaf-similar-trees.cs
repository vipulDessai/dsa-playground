namespace learning_dsa_csharp._07_trees._004_leaf_similar_trees
{
    internal class Solution
    {
        // simple DFS gets the result accurately
        // as in DFS first the bottom most node is visited
        // and is added to list and then go to the next
        public bool LeafSimilar_dfs(TreeNode root1, TreeNode root2)
        {
            List<int> getLeafNodes(TreeNode r)
            {
                var l = new List<int>();

                void dfs(TreeNode n)
                {
                    if (n.left == null && n.right == null)
                    {
                        l.Add((int)n.val);
                    }
                    else
                    {
                        if (n.left != null)
                        {
                            dfs(n.left);
                        }

                        if (n.right != null)
                        {
                            dfs(n.right);
                        }
                    }
                }

                dfs(r);

                return l;
            }

            var l1 = getLeafNodes(root1);
            var l2 = getLeafNodes(root2);

            return Enumerable.SequenceEqual(l1, l2);
        }

        // BFS doesnt work as we need to process the node right when we visit them and
        // not after all the node at that level are processed
        public bool LeafSimilar_queue(TreeNode root1, TreeNode root2)
        {
            List<int> getLeafNodes(TreeNode r)
            {
                var l = new List<int>();

                var q = new Queue<TreeNode>();
                q.Enqueue(r);

                while (q.Count > 0)
                {
                    var qLen = q.Count;

                    for (int i = 0; i < qLen; i++)
                    {
                        TreeNode n = q.Dequeue();

                        if (n.left == null && n.right == null)
                        {
                            l.Add((int)n.val);
                        }
                        else
                        {
                            if (n.left != null)
                            {
                                q.Enqueue(n.left);
                            }

                            if (n.right != null)
                            {
                                q.Enqueue(n.right);
                            }
                        }
                    }
                }

                return l;
            }

            var l1 = getLeafNodes(root1);
            var l2 = getLeafNodes(root2);

            return Enumerable.SequenceEqual(l1, l2);
        }
    }
}

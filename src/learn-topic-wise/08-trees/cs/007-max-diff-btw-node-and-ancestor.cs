namespace learning_dsa_csharp._07_trees._007_max_diff_btw_node_and_ancestor
{
    internal class Solution
    {
        public int MaxAncestorDiff(TreeNode root)
        {
            int max = 0;
            void dfs(TreeNode n, int greatAncestor, int weakAncestor)
            {
                if (n == null)
                {
                    return;
                }
                else
                {
                    int v = n.val == null ? -1 : (int)n.val;

                    if (greatAncestor - v > max)
                    {
                        max = greatAncestor - v;
                    }

                    if (v - weakAncestor > max)
                    {
                        max = v - weakAncestor;
                    }

                    greatAncestor = Math.Max(v, greatAncestor);
                    weakAncestor = Math.Min(v, weakAncestor);

                    dfs(n.left, greatAncestor, weakAncestor);
                    dfs(n.right, greatAncestor, weakAncestor);
                }
            }

            dfs(root, -1, int.MaxValue);

            return max;
        }
    }
}

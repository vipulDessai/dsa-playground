namespace learning_dsa_csharp._07_trees._002_lowest_common_ancester
{
    internal class Solution
    {
        // LCA is a node which is either common between p or q
        // or with itself
        // so that its the farthest from the root node
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode checkNode(TreeNode n)
            {
                if (n == null)
                {
                    return null;
                }

                // because if say suppose one of either p or q is found then
                // return it, as whichever is remaining and is below the current node then LCS is the current node only
                //
                // and only if its not the current then we go one more level down
                if (n.val == p.val || n.val == q.val)
                {
                    return n;
                }

                var lca1 = checkNode(n.left);
                var lca2 = checkNode(n.right);

                if (lca1 != null && lca2 != null)
                {
                    return n;
                }

                if (lca1 != null)
                {
                    return lca1;
                }
                if (lca2 != null)
                {
                    return lca2;
                }

                return null;
            }

            return checkNode(root);
        }
    }
}

namespace learning_dsa_csharp._07_trees._021_delete_nodes_and_return_forest
{
    internal class MySoln
    {
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            HashSet<int> to_delete_set;
            List<TreeNode> res;
            TreeNode Dfs(TreeNode node, bool is_root)
            {
                if (node == null)
                    return null;

                bool deleted = to_delete_set.Contains((int)node.val);
                if (is_root && !deleted)
                    res.Add(node);

                node.left = Dfs(node.left, deleted);
                node.right = Dfs(node.right, deleted);

                return deleted ? null : node;
            }

            to_delete_set = new HashSet<int>();
            res = new();

            foreach (int i in to_delete)
                to_delete_set.Add(i);

            Dfs(root, true);
            return res;
        }
    }
}

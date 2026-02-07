// https://leetcode.com/problems/delete-leaves-with-a-given-value/
namespace learning_dsa_csharp._07_trees._013_delete_leaves_with_a_given_values
{
    internal class MySoln
    {
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            bool dfs(TreeNode n)
            {
                if (n != null)
                {
                    if (n.left == null && n.right == null)
                    {
                        if (n.val == target)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        var l = dfs(n.left);
                        var r = dfs(n.right);

                        if (l)
                            n.left = null;

                        if (r)
                            n.right = null;

                        if (n.left == null && n.right == null)
                        {
                            if (n.val == target)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }

            return dfs(root) ? null : root;
        }
    }
}

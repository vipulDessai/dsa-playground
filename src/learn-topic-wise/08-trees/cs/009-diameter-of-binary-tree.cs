// https://leetcode.com/problems/diameter-of-binary-tree/
namespace learning_dsa_csharp._07_trees._009_diameter_of_binary_tree
{
    internal class OthersSoln
    {
        public int DiameterOfBinaryTree(TreeNode root)
        {
            (int, int) dfs(TreeNode n)
            {
                if (n == null)
                {
                    return (0, 0);
                }
                else
                {
                    var (cR_L, cB_L) = dfs(n.left);
                    var (cR_R, cB_R) = dfs(n.right);

                    int cR = Math.Max(cB_L + cB_R, Math.Max(cR_L, cR_R));
                    int cB = 1 + Math.Max(cB_L, cB_R);

                    return (cR, cB);
                }
            }

            var (d, sB) = dfs(root);
            return d;
        }
    }
}

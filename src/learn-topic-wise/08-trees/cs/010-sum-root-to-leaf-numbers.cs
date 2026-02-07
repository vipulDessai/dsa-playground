// https://leetcode.com/problems/sum-root-to-leaf-numbers/
namespace learning_dsa_csharp._07_trees._010_sum_root_to_leaf_numbers
{
    internal class MySoln
    {
        public int SumNumbers(TreeNode root)
        {
            int dfs(TreeNode n, int pS)
            {
                if (n != null)
                {
                    int cur = (pS * 10) + (int)n.val;
                    if (n.left == null && n.right == null)
                        return cur;
                    else
                    {
                        return dfs(n.left, cur) + dfs(n.right, cur);
                    }
                }
                else
                {
                    return 0;
                }
            }

            return dfs(root, 0);
        }
    }
}

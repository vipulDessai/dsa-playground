// https://leetcode.com/problems/distribute-coins-in-binary-tree/
namespace learning_dsa_csharp._07_trees._014_distribute_coins_in_a_tree
{
    // https://leetcode.com/problems/distribute-coins-in-binary-tree/solutions/5172544/move-coins-to-parent-dfs-0ms-beats-100
    internal class OthersSoln
    {
        public int DistributeCoins(TreeNode root)
        {
            int dfs(TreeNode n, TreeNode p)
            {
                if (n == null)
                    return 0;

                int m = dfs(n.left, n) + dfs(n.right, n);
                int x = (int)n.val - 1;

                if (p != null)
                {
                    p.val += x;
                }

                m += Math.Abs(x);

                return m;
            }

            return dfs(root, null);
        }
    }
}

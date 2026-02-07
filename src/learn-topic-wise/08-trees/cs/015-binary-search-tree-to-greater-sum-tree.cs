// https://leetcode.com/problems/distribute-coins-in-binary-tree/
namespace learning_dsa_csharp._07_trees._015_binary_search_tree_to_greater_sum_tree
{
    internal class MySoln
    {
        public TreeNode BstToGst(TreeNode root)
        {
            // inverse inorder traversal
            int dfs(TreeNode root, int rSum)
            {
                if (root == null)
                    return 0;

                int sum = rSum;
                sum += dfs(root.right, 0);
                sum += (int)root.val;
                root.val = sum;
                dfs(root.left, sum);

                return sum;
            }

            dfs(root, 0);

            return root;
        }
    }

    // https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree/solutions/5364272/inverse-inorder-without-helper-vs-iteration-0ms-beats-100
    internal class OthersSoln
    {
        int sum = 0;

        public TreeNode BstToGst(TreeNode root)
        {
            if (root == null)
                return root;

            BstToGst(root.right);
            sum += (int)root.val;
            root.val = sum;
            BstToGst(root.left);

            return root;
        }
    }
}

namespace learning_dsa_csharp._07_trees._003_range_sum_of_bst
{
    internal class Solution
    {
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            int r = 0;
            while (q.Count > 0)
            {
                var n = q.Dequeue();

                if (n.val >= low && n.val <= high)
                {
                    r += (int)n.val;
                }

                if (n.left != null)
                {
                    q.Enqueue(n.left);
                }
                if (n.right != null)
                {
                    q.Enqueue(n.right);
                }
            }

            return r;
        }
    }
}

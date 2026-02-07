namespace learning_dsa_csharp._07_trees._016_balance_a_binary_search_tree
{
    // https://leetcode.com/problems/balance-a-binary-search-tree/solutions/541785/c-java-with-picture-dsw-o-n-o-1
    internal class OthersSoln
    {
        int MakeVine(TreeNode grand)
        {
            int cnt = 0;
            var n = grand.right;
            while (n != null)
            {
                if (n.left != null)
                {
                    var old_n = n;
                    n = n.left;
                    old_n.left = n.right;
                    n.right = old_n;
                    grand.right = n;
                }
                else
                {
                    ++cnt;
                    grand = n;
                    n = n.right;
                }
            }
            return cnt;
        }

        void Compress(TreeNode grand, int m)
        {
            var n = grand.right;
            while (m-- > 0)
            {
                var old_n = n;
                n = n.right;
                grand.right = n;
                old_n.right = n.left;
                n.left = old_n;
                grand = n;
                n = n.right;
            }
        }

        public TreeNode BalanceBST(TreeNode root)
        {
            TreeNode grand = new TreeNode(0);
            grand.right = root;
            int cnt = MakeVine(grand);
            int m = (int)Math.Pow(2, (int)(Math.Log2(cnt + 1) / Math.Log2(2))) - 1;
            Compress(grand, cnt - m);

            for (m = m / 2; m > 0; m /= 2)
                Compress(grand, m);

            return grand.right;
        }
    }
}

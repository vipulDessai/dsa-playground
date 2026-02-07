namespace learning_dsa_csharp._07_trees._008_pseudo_palindromic_paths_in_binary_tree
{
    // problem - https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/?envType=daily-question&envId=2024-01-24
    internal class MySoln
    {
        public int PseudoPalindromicPaths(TreeNode root)
        {
            int dfs(TreeNode n, int[] cur, int len)
            {
                if (n == null)
                {
                    return 0;
                }

                if (n.left == null && n.right == null)
                {
                    cur[(int)n.val - 1]++;
                    var res = checkPal(cur, len + 1);
                    cur[(int)n.val - 1]--;
                    return res;
                }

                cur[(int)n.val - 1]++;
                var r = dfs(n.left, cur, len + 1) + dfs(n.right, cur, len + 1);
                cur[(int)n.val - 1]--;

                return r;
            }

            int checkPal(int[] c, int len)
            {
                if (len % 2 == 0)
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (c[i] % 2 != 0)
                        {
                            return 0;
                        }
                    }
                }
                else
                {
                    int oddCount = 0;
                    for (int i = 0; i < 9; ++i)
                    {
                        if (c[i] % 2 == 1)
                        {
                            oddCount++;
                        }

                        if (oddCount == 2)
                        {
                            return 0;
                        }
                    }
                }

                return 1;
            }

            int[] initC = new int[9];
            Array.Fill(initC, 0);
            return dfs(root, initC, 0);
        }
    }

    internal class Soln_Bit_manipulation
    {
        public int PseudoPalindromicPaths(TreeNode root)
        {
            int dfs(TreeNode n, int mask)
            {
                if (n == null)
                {
                    return 0;
                }

                mask ^= 1 << (int)n.val;

                if (n.left == null && n.right == null)
                {
                    return (mask & (mask - 1)) == 0 ? 1 : 0;
                }

                return dfs(n.left, mask) + dfs(n.right, mask);
            }

            return dfs(root, 0);
        }
    }
}

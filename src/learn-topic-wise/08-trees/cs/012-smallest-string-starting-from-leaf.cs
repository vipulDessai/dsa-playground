// https://leetcode.com/problems/add-one-row-to-tree/description/
namespace learning_dsa_csharp._07_trees._012_smallest_string_starting_from_leaf
{
    internal class MySoln
    {
        public string SmallestFromLeaf(TreeNode root)
        {
            string res = "";

            void dfs(TreeNode n, string cur)
            {
                cur = (char)('a' + n.val) + cur;

                if (n.left == null && n.right == null)
                {
                    if (res == "" || res.CompareTo(cur) == 1)
                    {
                        res = cur;
                    }
                }
                else
                {
                    if (n.left != null)
                        dfs(n.left, cur);

                    if (n.right != null)
                        dfs(n.right, cur);
                }
            }

            dfs(root, "");

            return res;
        }
    }
}

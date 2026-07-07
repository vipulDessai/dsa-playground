// [Lowest Common Ancestor of a Binary Tree](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/)

using Utils;

namespace learning_dsa_csharp._07_trees._002_lowest_common_ancester
{
    internal class Solution
    {
        private TreeNode dfs(TreeNode n, TreeNode p, TreeNode q)
        {
            if (n == null)
            {
                return null;
            }

            if (n == p || n == q)
            {
                return n;
            }

            var l = dfs(n.left, p, q);
            var r = dfs(n.right, p, q);

            if (l != null && r != null)
            {
                return n;
            }

            if (l != null)
            {
                return l;
            }

            if (r != null)
            {
                return r;
            }

            return null;
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return dfs(root, p, q);
        }
    }

    class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new();

            int?[] root = { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };

            TreeNode input = TreeOperations.Generate(root);
            TreeNode p1 = TreeOperations.Find(input, 5);
            TreeNode p2 = TreeOperations.Find(input, 1);

            var res = s.LowestCommonAncestor(input, p1, p2);

            Queue<TreeNode> q = new();
            q.Enqueue(res);

            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var cur = q.Dequeue();

                    Console.Write(cur.val + " ");

                    if (cur.left != null) q.Enqueue(cur.left);
                    if (cur.right != null) q.Enqueue(cur.right);
                }

                Console.WriteLine();
            }
        }
    }
}

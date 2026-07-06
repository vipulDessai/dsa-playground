// [Lowest Common Ancestor of a Binary Tree](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/)

using Utils;

namespace learning_dsa_csharp._07_trees._002_lowest_common_ancester
{
    internal class Solution
    {
        // LCA is a node which is either common between p or q
        // or with itself
        // so that its the farthest from the root node
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode checkNode(TreeNode n)
            {
                if (n == null)
                {
                    return null;
                }

                // because if say suppose one of either p or q is found then
                // return it, as whichever is remaining and is below the current node then LCS is the current node only
                //
                // and only if its not the current then we go one more level down
                if (n.val == p.val || n.val == q.val)
                {
                    return n;
                }

                var lca1 = checkNode(n.left);
                var lca2 = checkNode(n.right);

                if (lca1 != null && lca2 != null)
                {
                    return n;
                }

                if (lca1 != null)
                {
                    return lca1;
                }
                if (lca2 != null)
                {
                    return lca2;
                }

                return null;
            }

            return checkNode(root);
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

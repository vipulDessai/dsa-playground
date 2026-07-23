// https://leetcode.com/problems/add-one-row-to-tree/description/

using Utils;

namespace learning_dsa_csharp._07_trees._011_add_one_row_to_a_tree
{
    public class Solution
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                TreeNode n = new(val);
                n.left = root;
                return n;
            }

            Queue<TreeNode> q = new();
            q.Enqueue(root);

            int d = 0;
            while (q.Count > 0 && d < depth - 2)
            {
                var qLen = q.Count;

                for (var i = 0; i < qLen; ++i)
                {
                    var cur = q.Dequeue();

                    if (cur.left != null) q.Enqueue(cur.left);
                    if (cur.right != null) q.Enqueue(cur.right);
                }

                ++d;
            }

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                TreeNode nL = new(val);
                nL.left = cur.left;
                cur.left = nL;

                TreeNode nR = new(val);
                nR.right = cur.right;
                cur.right = nR;
            }

            return root;
        }
    }

    class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new();
            // int?[] arr = { 4, 2, 6, 3, 1, 5 };
            // int v = 1, d = 1;

            int?[] arr = { 1, 2, 3, 4 };
            int v = 5, d = 4;
            TreeNode root = TreeOperations.Generate(arr);

            var output = s.AddOneRow(root, v, d);

            TreeOperations.print(output);
        }
    }
}

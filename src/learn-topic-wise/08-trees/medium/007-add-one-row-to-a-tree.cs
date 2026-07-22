// https://leetcode.com/problems/add-one-row-to-tree/description/

using Utils;

namespace learning_dsa_csharp._07_trees._011_add_one_row_to_a_tree
{
    internal class Solution
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                TreeNode node = new(val);
                node.left = root;
                return node;
            }

            Queue<TreeNode> q = new();
            q.Enqueue(root);
            --depth;

            Queue<TreeNode> prevQ = new();

            while (q.Count > 0 && depth > 0)
            {
                prevQ.Clear();
                int qLen = q.Count;
                for (int i = 0; i < qLen; ++i)
                {
                    var curN = q.Dequeue();
                    prevQ.Enqueue(curN);

                    if (curN.left != null)
                        q.Enqueue(curN.left);

                    if (curN.right != null)
                        q.Enqueue(curN.right);
                }

                --depth;
            }

            while (prevQ.Count > 0)
            {
                var curN = prevQ.Dequeue();

                TreeNode nL = new(val);
                var tL = curN.left;
                curN.left = nL;
                nL.left = tL;

                TreeNode nR = new(val);
                var tR = curN.right;
                curN.right = nR;
                nR.right = tR;
            }

            return root;
        }
    }

    public class NewSoln
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
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

                if (cur.left != null)
                {
                    TreeNode newNode = new(val);
                    newNode.left = cur.left;
                    cur.left = newNode;
                }
                if (cur.right != null)
                {
                    TreeNode newNode = new(val);
                    newNode.right = cur.right;
                    cur.right = newNode;
                }
            }

            return root;
        }
    }

    class Execute
    {
        public static void Main(string[] args)
        {
            NewSoln s = new();
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

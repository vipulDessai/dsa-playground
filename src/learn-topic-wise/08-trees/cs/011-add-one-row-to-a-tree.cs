// https://leetcode.com/problems/add-one-row-to-tree/description/
namespace learning_dsa_csharp._07_trees._011_add_one_row_to_a_tree
{
    internal class MySoln
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                TreeNode node = new TreeNode(val, null, null);
                node.left = root;
                return node;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            --depth;

            Queue<TreeNode> prevQ = new Queue<TreeNode>();

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

                TreeNode nL = new TreeNode(val, null, null);
                var tL = curN.left;
                curN.left = nL;
                nL.left = tL;

                TreeNode nR = new TreeNode(val, null, null);
                var tR = curN.right;
                curN.right = nR;
                nR.right = tR;
            }

            return root;
        }
    }
}

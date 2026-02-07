using System.Text;

namespace learning_dsa_csharp._07_trees._001_dfs_bfs
{
    // refer - https://www.geeksforgeeks.org/bfs-vs-dfs-binary-tree/
    internal class DFS_Inorder_Preorder_PostOrder
    {
        public void traverseTree(TreeNode r)
        {
            Console.WriteLine(in_order(r));
            Console.WriteLine(pre_order(r));
            Console.WriteLine(post_order(r));
        }

        private string in_order(TreeNode r)
        {
            if (r == null)
            {
                return "";
            }

            return $"{in_order(r.left)} {r.val} {in_order(r.right)}";
        }

        private string pre_order(TreeNode r)
        {
            if (r == null)
            {
                return "";
            }

            return $"{r.val} {in_order(r.left)} {in_order(r.right)}";
        }

        private string post_order(TreeNode r)
        {
            if (r == null)
            {
                return "";
            }

            return $"{in_order(r.left)} {in_order(r.right)} {r.val}";
        }
    }

    internal class BFS_Level_order_traversal
    {
        // 1
        // 2 3
        // 4 5 6 7
        public void traverseTree(TreeNode r)
        {
            Console.WriteLine(level_order(r));
        }

        private string level_order(TreeNode r)
        {
            StringBuilder s = new StringBuilder();

            var q = new Queue<TreeNode>();
            q.Enqueue(r);

            while (q.Count > 0)
            {
                // very important to store the current queue length
                // before the child nodes are enqueued
                var qLen = q.Count;
                for (int i = 0; i < qLen; i++)
                {
                    TreeNode n = q.Dequeue();

                    s.Append($"{n.val} ");

                    if (n.left != null)
                    {
                        q.Enqueue(n.left);
                    }

                    if (n.right != null)
                    {
                        q.Enqueue(n.right);
                    }
                }
            }

            return s.ToString();
        }
    }
}

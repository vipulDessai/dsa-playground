namespace Utils
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreeOperations
    {
        public static TreeNode Generate(int?[] input)
        {
            int n = input.Length;

            if (n == 0 || input[0] is not int rootValue)
            {
                throw new ArgumentException("Input must contain a non-null root value.", nameof(input));
            }

            var root = new TreeNode(rootValue);

            Queue<TreeNode> q = new();
            q.Enqueue(root);

            int i = 1;
            while (q.Count > 0 && i < n)
            {
                var curNode = q.Dequeue();

                if (i < n && input[i] is int leftValue)
                {
                    curNode.left = new TreeNode(leftValue);
                    q.Enqueue(curNode.left);
                }
                ++i;

                if (i < n && input[i] is int rightValue)
                {
                    curNode.right = new TreeNode(rightValue);
                    q.Enqueue(curNode.right);
                }
                ++i;
            }

            return root;
        }

        public static TreeNode Find(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == val)
            {
                return root;
            }

            var lVal = Find(root.left, val);

            if (lVal != null) return root.left;

            var rVal = Find(root.right, val);

            if (rVal != null) return root.right;

            return null;
        }

        public static void print(TreeNode root)
        {
            Queue<TreeNode> q = new();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int qLen = q.Count;

                Console.WriteLine();

                for (int i = 0; i < qLen; ++i)
                {
                    TreeNode cur = q.Dequeue();

                    if (cur == null) continue;

                    Console.Write(cur.val + " ");

                    if (cur.left != null)
                    {
                        q.Enqueue(cur.left);
                    }
                    if (cur.right != null)
                    {
                        q.Enqueue(cur.right);
                    }
                }
            }
        }
    }
}
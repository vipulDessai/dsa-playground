// [Copy List with Random Pointer](https://leetcode.com/problems/copy-list-with-random-pointer/description/)

namespace learning_dsa_csharp._06_linked_list._004_copy_list_with_random_pointer
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    internal class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Dictionary<Node, Node> map = new();

            Node cur = head;
            while (cur != null)
            {
                Node copy = new Node(cur.val);
                map.Add(cur, copy);

                cur = cur.next;
            }

            cur = head;
            while (cur != null)
            {
                var copyNode = map[cur];
                copyNode.next = cur.next == null ? null : map[cur.next];
                copyNode.random = cur.random == null ? null : map[cur.random];

                cur = cur.next;
            }

            return map[head];
        }
    }

    internal class Execute
    {
        private static Node GenerateNodeLinkedList(int?[][] arr)
        {
            int n = arr.Length;
            var head = new Node(0);
            var next = head;

            Dictionary<int, Node> map = new();
            for (int i = 0; i < n; ++i)
            {
                next.val = arr[i][0] ?? 0;
                next.next = null;
                map[i] = next;

                if (i < n - 1)
                {
                    next = next.next = new Node(0);
                }
            }

            next = head;
            for (int i = 0; i < n; ++i)
            {
                int? randPtr = arr[i][1];
                next.random = randPtr.HasValue ? map[randPtr.Value] : null;
                next = next.next;
            }

            return head;
        }

        public static void Main(string[] args)
        {
            int?[][] input = [[7, null], [13, 0], [11, 4], [10, 2], [1, 0]];
            // input = [[3, null], [3, 0], [3, null]];
            Node inputList = GenerateNodeLinkedList(input);
            Solution s = new Solution();

            var output = s.CopyRandomList(inputList);

            while (output != null)
            {
                Console.WriteLine(output.val);
                Console.WriteLine(output.random?.val);

                output = output.next;
            }
        }
    }
}

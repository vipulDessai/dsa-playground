using System.Collections.Generic;

namespace learning_dsa_csharp._06_linked_list._004_copy_list_with_random_pointer
{
    internal class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Dictionary<Node, Node> oldToCopy = new Dictionary<Node, Node>();

            Node cur = head;
            while (cur != null)
            {
                Node copy = new Node(cur.val);
                oldToCopy.Add(cur, copy);
                cur = cur.next;
            }

            cur = head;
            while (cur != null)
            {
                Node copy = oldToCopy[cur];
                copy.next = cur.next == null ? null : oldToCopy[cur.next];
                copy.random = cur.random == null ? null : oldToCopy[cur.random];

                cur = cur.next;
            }

            return oldToCopy[head];
        }
    }
}

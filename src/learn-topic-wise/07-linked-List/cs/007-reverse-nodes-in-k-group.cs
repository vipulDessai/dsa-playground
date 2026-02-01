namespace learning_dsa_csharp._06_linked_list._007_reverse_nodes_in_k_group
{
    internal class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode groupPrev = dummy;

            while (true)
            {
                var kTh = GetKTh(groupPrev, k);

                // in case the group is not of length k
                if (kTh == null)
                    break;

                ListNode groupNext = kTh.next;

                ListNode prev = kTh.next;
                ListNode curr = groupPrev.next;

                ReverseLinkedList(curr, prev, groupNext);

                ListNode t = groupPrev.next;
                groupPrev.next = kTh;
                groupPrev = t;
            }

            return dummy.next;
        }

        private ListNode ReverseLinkedList(ListNode curr, ListNode prev, ListNode nextNode)
        {
            if (curr == nextNode)
            {
                return prev;
            }
            else
            {
                var next = curr.next;
                curr.next = prev;

                return ReverseLinkedList(next, curr, nextNode);
            }
        }

        private ListNode GetKTh(ListNode curr, int k)
        {
            while (curr != null && k > 0)
            {
                curr = curr.next;
                k--;
            }

            return curr;
        }
    }
}

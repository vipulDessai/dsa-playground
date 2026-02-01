namespace learning_dsa_csharp._06_linked_list._003_remove_nth_node_from_end_of_list
{
    internal class OthersSoln
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode l = dummy;
            ListNode r = head;

            while (n > 0 && r != null)
            {
                r = r.next;
                --n;
            }

            while (r != null)
            {
                r = r.next;
                l = l.next;
            }

            // delete the next node by pointing next to next of next node
            l.next = l.next.next;

            return dummy.next;
        }
    }

    internal class MySoln
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode t = new ListNode(0);
            t.next = head;

            ListNode l = t;
            ListNode r = head;

            while (n > 0 && r != null)
            {
                r = r.next;
                n--;
            }

            while (r != null)
            {
                r = r.next;
                l = l.next;
            }

            l.next = l.next.next;

            return head;
        }
    }
}

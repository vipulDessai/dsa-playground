namespace learning_dsa_csharp._06_linked_list._012_merge_in_between_linkedlist
{
    internal class MySoln
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var l2Tail = list2;
            while (l2Tail.next != null)
            {
                l2Tail = l2Tail.next;
            }

            var n = list1;
            ListNode s = null;
            ListNode e = null;

            int c = 1;
            while (n != null)
            {
                if (c == a)
                {
                    s = n;
                }

                if (c == b + 1)
                {
                    e = n;
                }

                n = n.next;
                ++c;
            }

            s.next = list2;
            l2Tail.next = e.next;

            return list1;
        }
    }
}

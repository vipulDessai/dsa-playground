namespace learning_dsa_csharp._06_linked_list._011_remove_zero_sum_consecutive_nodes_from_linked_list
{
    internal class MySoln
    {
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            if (head.next == null && head.val == 0)
            {
                return null;
            }

            Dictionary<int, ListNode> m = new Dictionary<int, ListNode>();

            var i = head;
            int s = 0;
            while (i != null)
            {
                s += (int)i.val;

                if (s == 0)
                {
                    head = i.next;
                    m = new Dictionary<int, ListNode>();
                }
                else
                {
                    if (m.ContainsKey(s))
                    {
                        var n = m[s];
                        n.next = i.next;

                        m = new Dictionary<int, ListNode>();
                        s = 0;
                        var j = head;
                        while (j != n.next)
                        {
                            s += (int)j.val;
                            m[s] = j;
                            j = j.next;
                        }
                    }
                    else
                    {
                        m[s] = i;
                    }
                }

                i = i.next;
            }

            if (s == 0)
            {
                return null;
            }

            return head;
        }
    }
}

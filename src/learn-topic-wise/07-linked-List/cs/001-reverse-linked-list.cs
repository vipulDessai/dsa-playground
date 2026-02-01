namespace learning_dsa_csharp._06_linked_list._001_reverse_linked_list
{
    internal class Solution
    {
        public ListNode Reverse(ListNode cur, ListNode prev)
        {
            if (cur == null)
            {
                return prev;
            }
            else
            {
                var next = cur.next;
                cur.next = prev;

                return Reverse(next, cur);
            }
        }
    }
}

namespace learning_dsa_csharp._06_linked_list._005_add_two_numbers
{
    internal class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode d = new ListNode();
            ListNode cur = d;

            int carry = 0;
            while (l1 != null || l2 != null || carry > 0)
            {
                int v1 = (int)(l1 != null ? l1.val : 0);
                int v2 = (int)(l2 != null ? l2.val : 0);

                // new digit
                int val = v1 + v2 + carry;

                carry = (val - (val % 10)) / 10; // Math.floor(val / 10)
                val = val % 10;

                cur.next = new ListNode(val);

                // update pointers
                cur = cur.next;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }

            // returning the next as the first one
            // value is empty
            return d.next;
        }
    }
}

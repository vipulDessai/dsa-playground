// https://leetcode.com/problems/double-a-number-represented-as-a-linked-list
namespace learning_dsa_csharp._06_linked_list._014_double_a_number_represented_as_a_linked_list
{
    // https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/solutions/5122942/beats-100-2ms-detailed-explanation-1-pointer-and-stack-tc-o-n-sc-o-1
    internal class OthersSoln
    {
        public ListNode DoubleIt(ListNode head)
        {
            // If the head's value is greater than 4,
            // insert a new node with value 0 at the beginning
            if (head.val > 4)
            {
                head = new ListNode(0, head);
            }

            ListNode temp = head;
            while (temp != null)
            {
                // Double the value and take modulo 10 to handle carry
                temp.val = (temp.val * 2) % 10;

                // If the next node exists and its value is greater than 4,
                // increment current node's value
                if (temp.next != null && temp.next.val > 4)
                {
                    temp.val++;
                }

                temp = temp.next; // Move to the next node
            }

            return head;
        }
    }
}

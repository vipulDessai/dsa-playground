// https://leetcode.com/problems/palindrome-linked-list
namespace learning_dsa_csharp._06_linked_list._012_palindrome_linked_list
{
    internal class MySoln
    {
        public bool IsPalindrome(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            ListNode n = head;
            while (n != slow)
            {
                int v = (int)n.val;
                n.val = n.next.val;
                n = n.next;
                n.val = v;
            }

            n = head;
            while (slow != null)
            {
                if (slow.val != n.val)
                {
                    return false;
                }

                n = n.next;
                slow = slow.next;
            }

            return true;
        }
    }
}

// [Reorder List](https://leetcode.com/problems/reorder-list/)

using Utils;

namespace learning_dsa_csharp._06_linked_list._002_reorder_list
{
    internal class Solution
    {
        public void ReorderList(ListNode head)
        {
            // find the middle
            ListNode slow = head,
                fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // reverse second half
            ListNode second = slow.next, prev = slow.next = null;
            while (second != null)
            {
                ListNode t = second.next;
                second.next = prev;
                prev = second;
                second = t;
            }

            // merge two halfs
            ListNode first = head;
            second = prev;
            while (second != null)
            {
                ListNode t1 = first.next,
                    t2 = second.next;
                second.next = t1;
                first.next = second;

                first = t1;
                second = t2;
            }
        }
    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();

            int[] input = [1, 2, 3, 4];

            var inputList = LinkedListGenerator.Generate(input);

            s.ReorderList(inputList);

            while (inputList != null)
            {
                Console.WriteLine(inputList.val);
                inputList = inputList.next;
            }
        }
    }
}

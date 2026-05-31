namespace Utils
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class LinkedListGenerator
    {
        public static ListNode Generate(int[] arr)
        {
            int n = arr.Length;
            var head = new ListNode();
            var next = head;
            for (int i = 0; i < n; ++i)
            {
                next.val = arr[i];
                next.next = null;

                if (i < n - 1)
                {
                    next.next = new ListNode();
                    next = next.next;
                }
            }

            return head;
        }
    }
}
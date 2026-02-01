using System.Collections.Generic;

namespace learning_dsa_csharp._06_linked_list._006_merge_k_sorted_list
{
    internal class Solution
    {
        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode h = new ListNode();
            ListNode t = h;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    t.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    t.next = l2;
                    l2 = l2.next;
                }

                t = t.next;
            }

            if (l1 != null)
            {
                t.next = l1;
            }

            if (l2 != null)
            {
                t.next = l2;
            }

            return h.next;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length > 0)
            {
                while (lists.Length > 1)
                {
                    List<ListNode> mergedLists = new List<ListNode>();

                    for (int i = 0; i < lists.Length; i = i + 2)
                    {
                        ListNode l1 = lists[i];
                        ListNode l2 = i + 1 < lists.Length ? lists[i + 1] : null;

                        mergedLists.Add(MergeTwoLists(l1, l2));
                    }

                    lists = mergedLists.ToArray();
                }

                return lists[0];
            }
            else
            {
                return null;
            }
        }
    }
}

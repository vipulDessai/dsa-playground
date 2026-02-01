namespace learning_dsa_csharp._06_linked_list
{
    // Definition for a linked list Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class ListNode
    {
        public int? val;
        public ListNode next { get; set; }

        public ListNode() { }

        public ListNode(int val)
        {
            this.val = val;
        }

        public ListNode(int val, ListNode node)
        {
            this.val = val;
            this.next = node;
        }
    }

    public class LinkedList
    {
        public ListNode list { get; set; }
        public Node head { get; set; }

        public LinkedList(int[] arr)
        {
            if (arr.Length > 0)
            {
                list = new ListNode(arr[0]);
                int i = 1;
                ListNode cur = list;
                do
                {
                    if (i < arr.Length)
                    {
                        cur.next = new ListNode(arr[i]);
                    }
                    cur = cur.next;
                    i++;
                } while (cur != null);
            }
            else
            {
                list = null;
            }
        }
    }

    class DS
    {
        public static void Main(string[] args)
        {
            var ds = new DS();
            // 1. Reverse linked list
            // l.ReverseLinkedList();

            // 2. Reorder linked list
            // l.ReorderList();

            // 3. Remove nth from end
            //l.RemoveNthFromEnd();

            // 4. Remove nth from end
            // l.CopyListWithRandomPointer();

            // 5. add two numbers
            // problem - https://leetcode.com/problems/add-two-numbers/
            // l.AddTwoNumbers();

            // 6. Merge k sorted lists
            // l.MergeKSortedLists();

            // 7. Reverse nodes in K-group
            // problem - https://leetcode.com/problems/merge-k-sorted-lists/
            // solution - https://www.youtube.com/watch?v=1UOPsfP85V4
            // l.ReverseNodesInKGroup();

            // 8. LRU Cache
            // problem - https://leetcode.com/problems/lru-cache/
            // solution - https://www.youtube.com/watch?v=7ABFKPK2hD4
            //l.LRUCache();

            // 9. Linked list cycle
            // problem - https://leetcode.com/problems/linked-list-cycle/
            // solution - https://www.youtube.com/watch?v=gBTe7lFR3vc
            //l.LinkedListCycle();

            // 10. Find the duplicate number
            // problem - https://leetcode.com/problems/find-the-duplicate-number/submissions/
            // solution - https://www.youtube.com/watch?v=wjYnzkAhcNk&t=9s
            //l.FindDuplicateNumber();

            //// l.RemoveZeroSumConsecutiveNodesFromLinkedList();

            // l.PalindromeLinkedList();

            //l.MergeBetweenLinkedLists();

            // l.DeleteNodeInBetween();

            // l.DoubleTheLinkedList();

            ds.FindMinMaxNumOfNodesBtwCriticalPoints();
        }

        private void ReverseLinkedList()
        {
            var s = new _001_reverse_linked_list.Solution();
            LinkedList l = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var reversedlist = s.Reverse(l.list, null);

            while (reversedlist != null)
            {
                Console.WriteLine(reversedlist.val);
                reversedlist = reversedlist.next;
            }
        }

        private void ReorderList()
        {
            var s = new _002_reorder_list.Solution();
            LinkedList l = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            s.ReorderList(l.list);

            while (l.list != null)
            {
                Console.WriteLine(l.list.val);
                l.list = l.list.next;
            }
        }

        private void RemoveNthFromEnd()
        {
            var s = new _003_remove_nth_node_from_end_of_list.MySoln();
            LinkedList curList = new LinkedList(new int[] { 1 });
            var h = s.RemoveNthFromEnd(curList.list, 1);

            while (h != null)
            {
                Console.WriteLine(h.val);
                h = h.next;
            }
        }

        private void CopyListWithRandomPointer()
        {
            var s = new _004_copy_list_with_random_pointer.Solution();

            Node n1 = new Node(7);
            Node n2 = new Node(13);
            Node n3 = new Node(11);
            Node n4 = new Node(10);
            Node n5 = new Node(1);
            n1.next = n2;
            n1.random = null;
            n2.next = n3;
            n2.random = n1;
            n3.next = n4;
            n3.random = n5;
            n4.next = n5;
            n4.random = n3;
            n5.next = null;
            n5.random = n1;

            var res = s.CopyRandomList(n1);

            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
        }

        private void AddTwoNumbers()
        {
            var s = new _005_add_two_numbers.Solution();

            LinkedList l1 = new LinkedList(new int[] { 7 });
            LinkedList l2 = new LinkedList(new int[] { 8 });
            var res = s.AddTwoNumbers(l1.list, l2.list);

            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
        }

        private void MergeKSortedLists()
        {
            var s = new _006_merge_k_sorted_list.Solution();

            LinkedList l1 = new LinkedList(new int[] { 1, 4, 5 });
            LinkedList l2 = new LinkedList(new int[] { 1, 3, 4 });
            LinkedList l3 = new LinkedList(new int[] { 2, 6 });
            ListNode[] lists = { l1.list, l2.list, l3.list };
            var res = s.MergeKLists(lists);

            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
        }

        private void ReverseNodesInKGroup()
        {
            var s = new _007_reverse_nodes_in_k_group.Solution();
            LinkedList l = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var res = s.ReverseKGroup(l.list, 3);

            while (res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
        }

        private void LRUCache()
        {
            string[] action = new string[]
            {
                "LRUCache",
                "put",
                "put",
                "get",
                "put",
                "get",
                "put",
                "get",
                "get",
                "get"
            };
            int[][] values = new int[action.Length][];
            values[0] = new int[] { 2 };
            values[1] = new int[] { 1, 1 };
            values[2] = new int[] { 2, 2 };
            values[3] = new int[] { 1 };
            values[4] = new int[] { 3, 3 };
            values[5] = new int[] { 2 };
            values[6] = new int[] { 4, 4 };
            values[7] = new int[] { 1 };
            values[8] = new int[] { 3 };
            values[9] = new int[] { 4 };

            var s = new _008_lru_cache.LRUCache(values[0][0]);
            for (int i = 1; i < action.Length; ++i)
            {
                var a = action[i];
                switch (a)
                {
                    case "get":
                        int res = s.Get(values[i][0]);
                        Console.WriteLine(res);
                        break;

                    case "put":
                        s.Put(values[i][0], values[i][1]);
                        break;
                }
            }
        }

        private void LinkedListCycle()
        {
            var s = new _009_linked_list_cycle.Solution_with_hash();
            LinkedList l = new LinkedList(
                [
                    -21,
                    10,
                    17,
                    8,
                    4,
                    26,
                    5,
                    35,
                    33,
                    -7,
                    -16,
                    27,
                    -12,
                    6,
                    29,
                    -12,
                    5,
                    9,
                    20,
                    14,
                    14,
                    2,
                    13,
                    -24,
                    21,
                    23,
                    -21,
                    5
                ]
            );
            Console.WriteLine(s.HasCycle(l.list));
        }

        private void FindDuplicateNumber()
        {
            var s = new _010_find_the_duplicate_number.Solution();
            var arr = new int[] { 1, 3, 4, 2, 2 };
            Console.WriteLine(s.FindDuplicate(arr));
        }

        private void RemoveZeroSumConsecutiveNodesFromLinkedList()
        {
            var s = new _011_remove_zero_sum_consecutive_nodes_from_linked_list.MySoln();
            var input = new LinkedList([1, 2, -3, 3, 1]);
            var r = s.RemoveZeroSumSublists(input.list);
            Console.WriteLine(r);
        }

        private void PalindromeLinkedList()
        {
            var s = new _012_palindrome_linked_list.MySoln();
            var input = new LinkedList([1, 2, 3, 2, 1]);
            input = new LinkedList([1, 2, 2, 1]);
            var r = s.IsPalindrome(input.list);
            Console.WriteLine(r);
        }

        private void MergeBetweenLinkedLists()
        {
            var s = new _012_merge_in_between_linkedlist.MySoln();
            var l1 = new LinkedList([10, 1, 13, 6, 9, 5]);
            int a = 3,
                b = 4;
            var l2 = new LinkedList([1000000, 1000001, 1000002]);
            var r = s.MergeInBetween(l1.list, a, b, l2.list);
            Console.WriteLine(r);
        }

        private void DeleteNodeInBetween()
        {
            var s = new _013_delete_node_in_a_linked_list.MySoln();

            var l = new LinkedList([10, 1, 13, 6, 9, 5]);
            s.DeleteNode(l.list.next.next.next);

            Console.WriteLine();
        }

        private void DoubleTheLinkedList()
        {
            var s = new _014_double_a_number_represented_as_a_linked_list.OthersSoln();

            var l = new LinkedList([10, 1, 13, 6, 9, 5]);
            s.DoubleIt(l.list);

            Console.WriteLine();
        }

        private void FindMinMaxNumOfNodesBtwCriticalPoints()
        {
            var s =
                new _015_find_the_minimum_and_maximum_number_of_nodes_between_critical_points.MySoln();

            var l = new LinkedList([5, 3, 1, 2, 5, 1, 2]);
            l = new LinkedList([1, 3, 2, 2, 3, 2, 2, 2, 7]);

            var r = s.NodesBetweenCriticalPoints(l.list);

            Console.WriteLine(r);
        }
    }
}

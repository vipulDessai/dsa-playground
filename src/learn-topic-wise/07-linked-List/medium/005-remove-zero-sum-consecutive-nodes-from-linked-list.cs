using Utils;

namespace learning_dsa_csharp._06_linked_list._011_remove_zero_sum_consecutive_nodes_from_linked_list
{
    public class Solution
    {
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            var cur = head;

            Dictionary<int, ListNode> map = new();
            map[0] = null;

            int pSum = 0;
            while (cur != null)
            {
                pSum += cur.val;

                if (map.ContainsKey(pSum))
                {
                    var lNode = map[pSum];

                    if (lNode == null)
                    {
                        head = cur.next;
                        map.Clear();
                        map[0] = null;
                    }
                    else
                    {
                        lNode.next = cur.next;
                        map.Clear();
                        map[0] = null;

                        // re calculate pSum and map
                        // from beginning to ensure updated list
                        var j = head;
                        pSum = 0;
                        while (j != lNode.next)
                        {
                            pSum += j.val;
                            map[pSum] = j;
                            j = j.next;
                        }
                    }
                }
                else
                {
                    if (!map.ContainsKey(pSum))
                        map[pSum] = cur;
                }

                cur = cur.next;
            }

            return head;
        }
    }

    class Execute
    {
        public static void Main(string[] args)
        {
            int[] input = [1, 2, -3, 3, 1];
            // input = [2, 2, -3, 3, 1];
            // input = [2, 1, -1, 3, 1, 4, 1, -1];
            input = [1, 2, 3, -3, -2];
            ListNode inputList = LinkedListGenerator.Generate(input);

            var output = new Solution().RemoveZeroSumSublists(inputList);

            while (output != null)
            {
                Console.WriteLine(output.val);
                output = output.next;
            }
        }
    }
}

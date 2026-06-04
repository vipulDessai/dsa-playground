using Utils;

namespace learning_dsa_csharp._06_linked_list._011_remove_zero_sum_consecutive_nodes_from_linked_list
{
    internal class Solution
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

    public class MySoln
    {
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            var cur = head;

            Dictionary<int, (ListNode, int)> map = new();
            map[0] = (null, -1);

            int pSum = 0, i = 0, max = int.MinValue;
            ListNode s = null, e = null;
            while (cur != null)
            {
                pSum += cur.val;

                if (map.ContainsKey(pSum))
                {
                    var (lNode, lInd) = map[pSum];

                    if (max < i - lInd)
                    {
                        max = i - lInd;
                        s = lNode;
                        e = cur;
                    }
                }

                if (!map.ContainsKey(pSum))
                    map[pSum] = (cur, i);

                cur = cur.next;
                ++i;
            }

            if(s == null && e == null)
            {
                return head;
            }

            if (s == null)
            {
                head = e.next;
            }
            else
            {
                s.next = e.next;
            }

            return head;
        }
    }

    class Execute
    {
        public static void Main(string[] args)
        {
            int[] input = [1, 2, -3, 3, 1];
            input = [2, 2, -3, 3, 1];
            ListNode inputList = LinkedListGenerator.Generate(input);

            var output = new MySoln().RemoveZeroSumSublists(inputList);

            while (output != null)
            {
                Console.WriteLine(output.val);
                output = output.next;
            }
        }
    }
}

// https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/description
namespace learning_dsa_csharp._06_linked_list._015_find_the_minimum_and_maximum_number_of_nodes_between_critical_points
{
    // https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/solutions/5418390/loop-linked-list-109ms-beats-99-27
    internal class OthersSoln_1_pass
    {
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            int i = 1,
                sz = 0,
                p0 = -1,
                p = -1,
                minD = int.MaxValue;
            int? x0 = head.val,
                x1 = head.next.val;
            bool less = x1 < x0,
                bigger = x1 > x0;
            for (ListNode Next = head.next.next; Next != null; i++, Next = Next.next)
            {
                int? x2 = Next.val;
                bool curBigger = x2 > x1,
                    curLess = x2 < x1;
                if ((less && curBigger) || (bigger && curLess))
                {
                    if (sz == 0)
                        p0 = i;
                    sz++;
                    if (p != -1)
                        minD = Math.Min(i - p, minD);
                    p = i;
                }
                bigger = curBigger;
                less = curLess;
                x1 = x2;
            }

            if (sz <= 1)
                return [-1, -1];
            else
                return [minD, p - p0];
        }
    }

    // https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/solutions/5418390/loop-linked-list-109ms-beats-99-27
    internal class OthersSoln_array
    {
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            List<int> pos = new List<int>();
            int i = 1;
            int? x0 = head.val,
                x1 = head.next.val;
            bool less = x1 < x0,
                bigger = x1 > x0;
            for (ListNode Next = head.next.next; Next != null; i++, Next = Next.next)
            {
                int? x2 = Next.val;
                bool curBigger = x2 > x1,
                    curLess = x2 < x1;
                if ((less && curBigger) || (bigger && curLess))
                {
                    pos.Add(i);
                }
                bigger = curBigger;
                less = curLess;
                x1 = x2;
            }

            int sz = pos.Count;
            if (sz <= 1)
            {
                return [-1, -1];
            }
            else
            {
                int maxD = pos[pos.Count - 1] - pos[0];
                int minD = int.MaxValue;
                for (int j = 0; j < sz - 1; j++)
                {
                    minD = Math.Min(minD, pos[j + 1] - pos[j]);
                }

                return [minD, maxD];
            }
        }
    }

    internal class MySoln
    {
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            List<int> pos = new List<int>();
            int i = 1;
            int? x0 = head.val,
                x1 = head.next.val;

            for (ListNode next = head.next.next; next != null; ++i, next = next.next)
            {
                int? x2 = next.val;

                bool ltPrev = x1 < x0,
                    gtPrev = x1 > x0;

                bool ltNext = x1 < x2,
                    gtNext = x1 > x2;

                if ((ltPrev && ltNext) || (gtPrev && gtNext))
                {
                    pos.Add(i);
                }

                x0 = x1;
                x1 = x2;
            }

            int sz = pos.Count;
            if (sz <= 1)
            {
                return [-1, -1];
            }
            else
            {
                int maxD = pos[pos.Count - 1] - pos[0];
                int minD = int.MaxValue;
                for (int j = 0; j < sz - 1; j++)
                {
                    minD = Math.Min(minD, pos[j + 1] - pos[j]);
                }

                return [minD, maxD];
            }
        }
    }
}

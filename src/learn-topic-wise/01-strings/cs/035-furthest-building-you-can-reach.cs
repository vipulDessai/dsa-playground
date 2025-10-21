// [furthest building you can reach](https://leetcode.com/problems/furthest-building-you-can-reach/) 

namespace learning_dsa_csharp._01_strings_arrays_hash._035_furthest_building_you_can_reach
{
    internal class MySoln
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int n = heights.Length;
            var pQ = new PriorityQueue<int>();
            pQ.compare = (x, y) => x.CompareTo(y);

            for (int i = 1; i < n; i++)
            {
                int cur = heights[i] - heights[i - 1];

                if (cur > 0)
                {
                    pQ.Enqueue(cur);

                    if (pQ.Count > ladders)
                    {
                        var minH = pQ.Dequeue();
                        bricks -= minH;
                        if (bricks < 0)
                        {
                            return i - 1;
                        }
                    }
                }
            }

            return n - 1;
        }
    }
}

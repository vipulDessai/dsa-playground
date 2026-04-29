// https://leetcode.com/problems/count-subarrays-with-fixed-bounds/
namespace learning_dsa_csharp._03_sliding_window._008_count_subarrays_with_fixed_bounds
{
    // only one basic test case is covered
    internal class MySoln
    {
        private int dfs(int i, int[] nums, int start, MinHeap minH, int minK, int maxK)
        {
            if (i < start)
            {
                return 0;
            }

            int curI = nums[i];
            minH.Remove(curI);

            if (minH.Peek == minK && minH.PeekEnd == maxK)
            {
                int res = 1 + dfs(i - 1, nums, start, minH, minK, maxK);
                minH.Add(curI);
                return res;
            }
            else
            {
                minH.Add(curI);
                return 0;
            }
        }

        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            int n = nums.Length;
            long res = 0;
            int l = 0,
                r = 0;
            MinHeap minH = new MinHeap([]);

            while (r < n)
            {
                int cur = nums[r];
                minH.Add(cur);

                if (minH.Peek < minK || minH.PeekEnd > maxK)
                {
                    int tR = r;
                    minH.Remove(cur);
                    --r;

                    while (minH.Peek == minK && minH.PeekEnd == maxK)
                    {
                        res += 1 + dfs(r, nums, l, minH, minK, maxK);

                        int curL = nums[l];
                        minH.Remove(curL);
                        ++l;
                    }

                    l = r = tR;
                }

                ++r;
            }

            return res;
        }
    }
}

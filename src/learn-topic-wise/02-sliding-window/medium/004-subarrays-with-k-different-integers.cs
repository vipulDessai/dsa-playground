// [Subarrays with K Different Integers](https://leetcode.com/problems/subarrays-with-k-different-integers)

namespace learning_dsa_csharp._03_sliding_window._007_subarrays_with_k_different_integers
{
    internal class OthersSoln
    {
        private int UniqueSubarrayLength(int[] nums, int k)
        {
            int n = nums.Length;
            Dictionary<int, int> m = new Dictionary<int, int>();

            int l = 0,
                r = 0,
                res = 0;
            while (r < n)
            {
                int cur = nums[r];

                if (!m.ContainsKey(cur))
                {
                    m[cur] = 0;
                }
                ++m[cur];

                while (m.Count > k)
                {
                    int curL = nums[l];
                    --m[curL];

                    if (m[curL] == 0)
                    {
                        m.Remove(curL);
                    }

                    ++l;

                    res += n - (r - 1);
                }

                ++r;
            }

            return res;
        }

        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            // formula
            return UniqueSubarrayLength(nums, k) - UniqueSubarrayLength(nums, k - 1);
        }
    }
}

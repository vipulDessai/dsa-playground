// https://leetcode.com/problems/subarrays-with-k-different-integers
namespace learning_dsa_csharp._03_sliding_window._007_subarrays_with_k_different_integers
{
    // https://leetcode.com/problems/subarrays-with-k-different-integers/solutions/4944691/simplified-algorithm-explained-with-visual-example-c-java
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
            return UniqueSubarrayLength(nums, k) - UniqueSubarrayLength(nums, k - 1);
        }
    }

    // TODO - needs to be fixed
    internal class MySoln
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

                if (m.Count > k)
                {
                    --r;
                    --m[cur];
                    if (m[cur] == 0)
                    {
                        m.Remove(cur);
                    }

                    while (m.Count == k)
                    {
                        int curL = nums[l];
                        --m[curL];

                        if (m[curL] == 0)
                        {
                            m.Remove(curL);
                        }

                        res += n - r;

                        ++l;
                    }
                }

                ++r;
            }

            return res;
        }

        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            var l1 = UniqueSubarrayLength(nums, k - 1);
            var l2 = UniqueSubarrayLength(nums, k);
            return (l1 - l2) - 1;
        }
    }
}

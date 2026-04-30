// [Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit](https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/description/)

namespace learning_dsa_csharp._03_sliding_window._011_longest_continuous_subarray_with_absolute_diff_less_than_or_equal_to_limit
{
    internal class MySoln
    {
        public int LongestSubarray(int[] nums, int limit)
        {
            int n = nums.Length;

            LinkedList<int> decQ = new LinkedList<int>();
            LinkedList<int> incQ = new LinkedList<int>();

            int ans = 0;
            int l = 0,
                r = 0;

            while (r < n)
            {
                int num = nums[r];

                while (decQ.Count > 0 && num > decQ.Last.Value)
                {
                    decQ.RemoveLast();
                }
                decQ.AddLast(num);

                while (incQ.Count > 0 && num < incQ.Last.Value)
                {
                    incQ.RemoveLast();
                }
                incQ.AddLast(num);

                while (decQ.First.Value - incQ.First.Value > limit)
                {
                    if (decQ.First.Value == nums[l])
                    {
                        decQ.RemoveFirst();
                    }
                    if (incQ.First.Value == nums[l])
                    {
                        incQ.RemoveFirst();
                    }
                    ++l;
                }

                ans = Math.Max(ans, r - l + 1);

                ++r;
            }

            return ans;
        }
    }
}

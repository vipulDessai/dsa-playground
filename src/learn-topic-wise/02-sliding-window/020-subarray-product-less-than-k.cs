// [Subarray Product Less Than K](https://leetcode.com/problems/subarray-product-less-than-k/)

namespace learning_dsa_csharp._03_sliding_window._020_subarray_product_less_than_k
{
    internal class MySoln
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k == 0)
                return 0;

            int n = nums.Length;

            int l = 0,
                r = 0,
                c = 0,
                p = 1;
            while (r < n)
            {
                if (p < k)
                {
                    p *= nums[r];
                    ++r;
                }
                else
                {
                    p /= nums[l];
                    ++l;
                }

                c += r - l;
            }

            return c;
        }
    }

    // https://leetcode.com/problems/subarray-product-less-than-k/solutions/560093/python3-two-pointer-o-n-o-1-with-breakdown
    class OthersSoln
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int count = 0;
            int dp_index = 0;
            int sum = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                sum *= nums[i];
                while (sum >= k && dp_index <= i)
                {
                    sum /= nums[dp_index];
                    dp_index++;
                }
                count += i - dp_index + 1;
            }
            return count;
        }
    }
}

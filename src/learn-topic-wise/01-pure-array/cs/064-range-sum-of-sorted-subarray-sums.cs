// https://leetcode.com/problems/range-sum-of-sorted-subarray-sums/description
namespace learning_dsa_csharp._01_strings_arrays_hash._064_range_sum_of_sorted_subarray_sums
{
    internal class MySoln
    {
        public int RangeSum(int[] nums, int n, int left, int right)
        {
            int m = (n * (n + 1)) / 2;
            int[] sums = new int[m];
            int sumsInd = 0;
            for (int i = 0; i < n; ++i)
            {
                int sum = 0;
                for (int j = i; j < n; ++j)
                {
                    sum += nums[j];
                    sums[sumsInd++] += sum;
                }
            }

            Array.Sort(
                sums,
                (a, b) =>
                {
                    return a.CompareTo(b);
                }
            );

            int res = 0;
            long MOD = 1000000007;
            for (int i = left - 1; i < right; ++i)
            {
                res = (int)((res + sums[i]) % MOD);
            }

            return res;
        }
    }
}

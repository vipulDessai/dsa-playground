namespace learning_dsa_csharp._01_strings_arrays_hash._016_smallest_missing_integer_gte_sequential_prefix_sum
{
    // problem - https://leetcode.com/problems/smallest-missing-integer-greater-than-sequential-prefix-sum/description/
    internal class Solution
    {
        public int MissingInteger(int[] nums)
        {
            int prev = nums[0];
            int prefixSum = nums[0];
            int maxPrefixSum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - 1 == prev)
                {
                    prefixSum += nums[i];
                }
                else
                {
                    break;
                }

                prev = nums[i];
            }

            if (maxPrefixSum < prefixSum)
            {
                maxPrefixSum = prefixSum;
            }

            Dictionary<int, int> dp = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dp[nums[i]] = 1;
            }

            while (true)
            {
                if (dp.ContainsKey(maxPrefixSum))
                {
                    maxPrefixSum++;
                }
                else
                {
                    break;
                }
            }

            return maxPrefixSum;
        }
    }
}

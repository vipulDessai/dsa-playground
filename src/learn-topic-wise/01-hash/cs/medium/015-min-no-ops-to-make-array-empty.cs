// export const url = "[2870. Minimum Number of Operations to Make Array Empty](https://leetcode.com/problems/minimum-number-of-operations-to-make-array-empty/description/)"

namespace learning_dsa_csharp._01_strings_arrays_hash._015_min_no_ops_to_make_array_empty
{
    internal class Solution
    {
        // TLE for 740 AC
        public int MinOperations_with_dp(int[] nums)
        {
            Dictionary<int, int> c = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!c.ContainsKey(nums[i]))
                {
                    c[nums[i]] = 0;
                }

                c[nums[i]]++;
            }

            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
            int countOps(int val, int divisible, int c)
            {
                val = val - divisible;

                if (val < 0)
                {
                    return int.MaxValue;
                }

                if (val == 0)
                {
                    return c + 1;
                }

                if (val - 3 == 0 || val - 2 == 0)
                {
                    return c + 2;
                }

                if (dp.ContainsKey((val, c)))
                {
                    return dp[(val, c)];
                }

                var resCount = Math.Min(countOps(val, 3, c + 1), countOps(val, 2, c + 1));

                dp.Add((val, c), resCount);

                return resCount;
            }

            int res = 0;
            foreach (var (key, val) in c)
            {
                int curCount = Math.Min(countOps(val, 3, 0), countOps(val, 2, 0));

                if (curCount == int.MaxValue)
                {
                    return -1;
                }
                else
                {
                    res += curCount;
                }
            }

            return res;
        }

        // fails for count number like 13
        public int MinOperations_my_own_counting(int[] nums)
        {
            Dictionary<int, int> c = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!c.ContainsKey(nums[i]))
                {
                    c[nums[i]] = 0;
                }

                c[nums[i]]++;
            }

            int count = 0;
            foreach (var (key, value) in c)
            {
                int t = value;

                if (t % 2.5 == 0)
                {
                    count += (int)(value / 2.5);
                }
                else if (t % 3 == 0)
                {
                    count += value / 3;
                }
                else if (t % 2 == 0)
                {
                    count += value / 2;
                }
                else
                {
                    return -1;
                }
            }

            return count;
        }

        public int MinOperations(int[] nums)
        {
            Dictionary<int, int> c = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!c.ContainsKey(nums[i]))
                {
                    c[nums[i]] = 0;
                }

                c[nums[i]]++;
            }

            int count = 0;
            foreach (var (key, value) in c)
            {
                int t = value;
                if (t == 1)
                    return -1;
                count += (int)Math.Floor(t / 3.0);
                if (t % 3 != 0)
                    count++;
            }

            return count;
        }
    }
}

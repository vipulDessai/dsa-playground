namespace learning_dsa_csharp._13_1_d_dynamic_programming._004_longest_increasing_subsequence
{
    internal class Solution
    {
        public int BruteForce_LengthOfLIS(int[] nums)
        {
            int recursion(int i, int prev)
            {
                if (i == nums.Length)
                    return 0;

                int t1 = 0,
                    t2 = recursion(i + 1, prev);

                if (nums[i] > prev)
                {
                    t1 = 1 + recursion(i + 1, nums[i]);
                }

                return Math.Max(t1, t2);
            }

            return recursion(0, int.MinValue);
        }

        public int Memoised_BruteForce_LengthOfLIS(int[] nums)
        {
            int[][] dp = new int[nums.Length + 2][];
            for (int i = 0; i < nums.Length + 2; ++i)
            {
                dp[i] = new int[nums.Length + 2];
                for (int j = 0; j < nums.Length + 2; ++j)
                {
                    dp[i][j] = -1;
                }
            }
            int recursion(int i, int prev_i)
            {
                if (i == nums.Length)
                    return 0;

                if (dp[i][prev_i + 1] != -1)
                {
                    return dp[i][prev_i + 1];
                }

                int t1 = 0,
                    t2 = recursion(i + 1, prev_i);

                if (prev_i == -1 || nums[i] > nums[prev_i])
                {
                    t1 = 1 + recursion(i + 1, i);
                }

                return dp[i][prev_i + 1] = Math.Max(t1, t2);
            }

            return recursion(0, -1);
        }

        public int Memoised_Improved_BruteForce_LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length + 2];
            for (int i = 0; i < nums.Length + 2; ++i)
            {
                dp[i] = -1;
            }

            int recursion(int i, int prev_i)
            {
                if (i == nums.Length)
                    return 0;

                if (dp[prev_i + 1] != -1)
                {
                    return dp[prev_i + 1];
                }

                int t1 = 0,
                    t2 = recursion(i + 1, prev_i);

                if (prev_i == -1 || nums[i] > nums[prev_i])
                {
                    t1 = 1 + recursion(i + 1, i);
                }

                return dp[prev_i + 1] = Math.Max(t1, t2);
            }

            return recursion(0, -1);
        }

        // Fails at 45/55 test case beacuse leetcode expects this solution to be O(N * log N)
        // But it passes if test case in imported in "Run" option
        public int LengthOfLIS_my_own_soln(int[] nums)
        {
            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

            int dfs(int i, int prev_i)
            {
                if (i >= nums.Length)
                {
                    return 0;
                }

                if (dp.ContainsKey((i, prev_i)))
                {
                    return dp[(i, prev_i)];
                }

                if (prev_i == -1 || nums[i] > nums[prev_i])
                {
                    var r = Math.Max(1 + dfs(i + 1, i), dfs(i + 1, prev_i));
                    dp[(i, prev_i)] = r;
                    return r;
                }
                else
                {
                    var r = dfs(i + 1, prev_i);
                    dp[(i, prev_i)] = r;
                    return r;
                }
            }

            return dfs(0, -1);
        }
    }
}

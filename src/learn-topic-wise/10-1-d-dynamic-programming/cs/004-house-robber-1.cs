namespace learning_dsa_csharp._13_1_d_dynamic_programming._003_house_robber_1
{
    internal class Solution
    {
        int[] n;
        int[] memo;

        public int Rob(int[] nums)
        {
            n = nums;
            memo = new int[nums.Length + 1];
            for (int i = 0; i < memo.Length; ++i)
            {
                memo[i] = -1;
            }

            //var r = RobRecursive(nums.Length - 1);
            var r = RobIterative();
            //var r = RobIterative2Vars();

            for (int i = 0; i < memo.Length; ++i)
            {
                Console.WriteLine(memo[i]);
            }

            return r;
        }

        private int RobRecursive(int i)
        {
            if (i < 0)
            {
                return 0;
            }
            if (memo[i] >= 0)
            {
                return memo[i];
            }

            int r = Math.Max(RobRecursive(i - 2) + n[i], RobRecursive(i - 1));
            memo[i] = r;
            return r;
        }

        private int RobIterative()
        {
            if (n.Length == 0)
                return 0;

            memo[0] = 0;
            memo[1] = n[0];

            for (int i = 1; i < n.Length; ++i)
            {
                memo[i + 1] = Math.Max(memo[i], memo[i - 1] + n[i]);
            }

            return memo[n.Length];
        }

        private int RobIterative2Vars()
        {
            if (n.Length == 0)
                return 0;

            int p1 = 0;
            int p2 = 0;

            foreach (var num in n)
            {
                int t = p2;
                p2 = Math.Max(p1 + num, p2);
                p1 = t;
            }

            return p2;
        }
    }

    internal class MyRetry_top_down
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;

            int[] dp = new int[n];
            Array.Fill(dp, -1);
            int dfs(int i)
            {
                if (i >= n)
                {
                    return 0;
                }

                if (dp[i] != -1)
                {
                    return dp[i];
                }

                dp[i] = Math.Max(nums[i] + dfs(i + 2), dfs(i + 1));
                return dp[i];
            }

            return dfs(0);
        }
    }

    internal class MyRetry_bottom_up
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;

            if (n == 1)
            {
                return nums[0];
            }

            int[] dp = new int[n];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; ++i)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[n - 1];
        }
    }

    internal class MyRetry_bottom_up_optimized
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;

            if (n == 1)
            {
                return nums[0];
            }

            int dp0 = nums[0];
            int dp1 = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; ++i)
            {
                (dp0, dp1) = (dp1, Math.Max(nums[i] + dp0, dp1));
            }

            return dp1;
        }
    }
}

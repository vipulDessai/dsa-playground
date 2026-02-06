namespace learning_dsa_csharp._13_1_d_dynamic_programming._014_climbing_stairs_i
{
    // https://leetcode.com/problems/climbing-stairs/?envType=daily-question&envId=2024-01-18
    internal class FibonacciApproachDpSolution
    {
        int[] dp;

        public int ClimbStairs(int n)
        {
            dp = new int[n + 1];
            Array.Fill(dp, -1);

            return CountSteps(n);
        }

        private int CountSteps(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            if (dp[n] != -1)
            {
                return dp[n];
            }

            dp[n] = CountSteps(n - 1) + CountSteps(n - 2);
            return dp[n];
        }
    }

    internal class FibonacciApproachIterativeBottomUpSolution
    {
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];

            dp[0] = dp[1] = 1;

            for (int i = 2; i < n + 1; ++i)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}

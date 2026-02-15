using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._14_2_d_dynamic_programming._006_burst_balloons
{
    internal class Solution
    {
        public int MaxCoins(int[] nums)
        {
            List<int> n = new List<int>() { 1 };
            for (int i = 0; i < nums.Length; ++i)
            {
                n.Add(nums[i]);
            }
            n.Add(1);

            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

            int dfs(int l, int r)
            {
                if (l > r)
                {
                    return 0;
                }
                if (dp.ContainsKey((l, r)))
                {
                    return dp[(l, r)];
                }

                dp[(l, r)] = 0;

                for (int i = l; i < r + 1; i++)
                {
                    int coins = n[l - 1] * n[i] * n[r + 1];
                    coins += dfs(l, i - 1) + dfs(i + 1, r);
                    dp[(l, r)] = Math.Max(dp[(l, r)], coins);
                }

                return dp[(l, r)];
            }

            return dfs(1, n.Count - 2);
        }

        public int MaxCoins_BottomUp(int[] nums)
        {
            int n = nums.Length;
            int[] balloons = new int[n + 2];
            balloons[0] = 1;
            for (int i = 0; i < n; i++)
            {
                balloons[i + 1] = nums[i];
            }
            balloons[n + 1] = 1;

            n = balloons.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }

            for (int i = n - 3; i >= 0; i--)
            {
                for (int j = i + 2; j < n; j++)
                {
                    if (j - i == 2)
                    {
                        dp[i][j] = balloons[i] * balloons[i + 1] * balloons[j];
                    }
                    else
                    {
                        for (int index = i + 1; index < j; index++)
                        {
                            dp[i][j] = Math.Max(
                                dp[i][j],
                                balloons[i] * balloons[index] * balloons[j]
                                    + dp[i][index]
                                    + dp[index][j]
                            );
                        }
                    }
                }
            }
            return dp[0][n - 1];
        }
    }
}

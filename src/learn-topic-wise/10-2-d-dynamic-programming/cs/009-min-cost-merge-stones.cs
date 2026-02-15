using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._14_2_d_dynamic_programming._009_min_cost_merge_stones
{
    internal class Solution
    {
        // solution - https://leetcode.com/problems/minimum-cost-to-merge-stones/solutions/247657/java-bottom-up-top-down-dp-with-explaination/
        public int MergeStones_Top_down(int[] stones, int k)
        {
            int[,,] dp;
            int max = int.MaxValue;
            int len = stones.Length;
            if ((len - 1) % (k - 1) != 0)
            {
                return -1;
            }
            dp = new int[len + 1, len + 1, k + 1];
            int[] prefixSum = new int[len + 1];

            int i;
            for (i = 1; i <= len; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + stones[i - 1];
            }

            return getResult(1, len, 1);

            int getResult(int left, int right, int piles)
            {
                if (dp[left, right, piles] != 0)
                {
                    return dp[left, right, piles];
                }
                int res = max;
                int t;
                if (left == right)
                {
                    res = (piles == 1) ? 0 : max;
                }
                else
                {
                    if (piles == 1)
                    {
                        res = getResult(left, right, k) + prefixSum[right] - prefixSum[left - 1];
                    }
                    else
                    {
                        for (t = left; t < right; t++)
                        {
                            res = Math.Min(
                                res,
                                getResult(left, t, piles - 1) + getResult(t + 1, right, 1)
                            );
                        }
                    }
                }
                dp[left, right, piles] = res;
                return res;
            }
        }

        // solution - https://leetcode.com/problems/minimum-cost-to-merge-stones/solutions/1432667/explained-to-make-you-visualise-the-solution-detailed-explanation/
        public int MergeStones_Top_down_solution_2(int[] stones, int k)
        {
            // the size of the stones
            int n = stones.Length;
            var dp = new int[n, n, k + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int l = 0; l < k + 1; l++)
                    {
                        dp[i, j, l] = -1;
                    }
                }
            }

            /*
            Check whether we will be able to merge n piles into 1 pile .

                In step-1 we merge k pile and then we are left with n-k+1 piles or n-(k-1);
                In Step-2 we again merge k pile and then we are left with ((n-k+1)-k)+1 or n-2*(k-1);
                In Step-3 we gain merge k pile and left with (((n-k+1)-k+1)-k)+1 or n-3*(k-1)
                .......
                .......
                .......
                After some m steps we should be left with 1 pile
                Therefore , n-m*(k-1) == 1
                       (n-1)-m*(k-1)=0;
                       Since m needs to be an integer therefore ,
                       if (n-1)%(k-1) == 0 ,
                       then we can merge otherwise not possible.
            */

            if ((n - 1) % (k - 1) != 0)
                return -1;

            int sum = 0;
            List<int> prefixsum = new List<int>();
            // Calculating the prefix sum so that sum of any segment[i..j] can be calculated easily
            for (int i = 0; i < n; i++)
            {
                sum += stones[i];
                prefixsum.Add(sum);
            }

            // find the minimum cost to merge stones[0...n-1] into 1 pile
            var res = minCost(0, n - 1, 1);
            return res;

            int minCost(int i, int j, int piles)
            {
                // Cost of converting segment [i..i] into 1 pile is zero
                if (i == j && piles == 1)
                    return 0;

                // Cost of converting segment[i..i] into other than 1 pile is not possible , so placed MAX value
                if (i == j)
                    return int.MaxValue;

                // Check whether the subproblem has already been solved .
                if (dp[i, j, piles] != -1)
                    return dp[i, j, piles];

                // If segment[i...j] is to converted into 1 pile
                if (piles == 1)
                {
                    // Here dp(i,j,1) = dp(i,j,K) + sum[i...j]
                    return dp[i, j, 1] =
                        minCost(i, j, k)
                        + (i == 0 ? prefixsum[j] : prefixsum[j] - prefixsum[i - 1]);
                }
                else
                {
                    // dp(i,j,piles) = min( dp(i,j,piles), dp(i,t,1) + dp(t+1,j,piles-1)) for all t E i<=t<j
                    int cost = int.MaxValue;
                    for (int t = i; t < j; t++)
                    {
                        cost = Math.Min(cost, minCost(i, t, 1) + minCost(t + 1, j, piles - 1));
                    }
                    return dp[i, j, piles] = cost;
                }
            }
        }

        // current status - TLE
        public int MergeStones_my_own_solution_brute_force(int[] stones, int k)
        {
            if (stones.Length < k)
            {
                return 0;
            }

            return dfs(stones, 0);

            int dfs(int[] rocks, int t)
            {
                if (rocks.Length == k)
                {
                    var res = 0;
                    for (int i = 0; i < rocks.Length; ++i)
                    {
                        res += rocks[i];
                    }

                    return res + t;
                }

                if (rocks.Length < k)
                {
                    return -1;
                }

                var minSum = int.MaxValue;
                for (int i = 0; i < rocks.Length; ++i)
                {
                    if (i + k > rocks.Length)
                    {
                        break;
                    }

                    var newSum = 0;
                    for (int j = i; j < i + k; ++j)
                    {
                        newSum += rocks[j];
                    }

                    int[] newStones = new int[rocks.Length - k + 1];
                    for (int j = 0; j < newStones.Length; ++j)
                    {
                        if (j < i)
                        {
                            newStones[j] = rocks[j];
                        }
                        else if (j == i)
                        {
                            newStones[j] = newSum;
                        }
                        else
                        {
                            newStones[j] = rocks[j + k - 1];
                        }
                    }

                    minSum = Math.Min(minSum, dfs(newStones, t + newSum));
                }

                return minSum;
            }
        }

        // current status - fails to pick the correct dp value
        // i.e memoisation fails
        public int MergeStones_my_own_solution_top_down(int[] stones, int k)
        {
            if (stones.Length < k)
            {
                return 0;
            }

            Dictionary<string, int> dp = new Dictionary<string, int>();

            return dfs(stones, 0);

            int dfs(int[] rocks, int t)
            {
                if (rocks.Length == k)
                {
                    var res = 0;
                    for (int i = 0; i < rocks.Length; ++i)
                    {
                        res += rocks[i];
                    }
                    return res + t;
                }

                if (rocks.Length < k)
                {
                    return -1;
                }

                var minSum = int.MaxValue;
                for (int i = 0; i < rocks.Length; ++i)
                {
                    if (i + k > rocks.Length)
                    {
                        break;
                    }

                    var newSum = 0;
                    for (int j = i; j < i + k; ++j)
                    {
                        newSum += rocks[j];
                    }

                    int[] newStones = new int[rocks.Length - k + 1];
                    string comboSumItems = "";
                    for (int j = 0; j < newStones.Length; ++j)
                    {
                        if (j < i)
                        {
                            newStones[j] = rocks[j];
                            comboSumItems += newStones[j].ToString() + ',';
                        }
                        else if (j == i)
                        {
                            newStones[j] = newSum;
                            comboSumItems += newStones[j].ToString() + ',';
                        }
                        else
                        {
                            newStones[j] = rocks[j + k - 1];
                            comboSumItems += newStones[j].ToString() + ',';
                        }
                    }

                    if (dp.ContainsKey(comboSumItems))
                    {
                        minSum = Math.Min(minSum, t + dp[comboSumItems]);
                    }
                    else
                    {
                        minSum = Math.Min(minSum, dfs(newStones, t + newSum));
                        dp[comboSumItems] = minSum - t;
                    }
                }

                return minSum;
            }
        }
    }
}

// problem - https://leetcode.com/problems/coin-change/
namespace learning_dsa_csharp._13_1_d_dynamic_programming._002_coin_change
{
    internal class Solution
    {
        public int CoinChangeBacktracking(int[] coins, int amount)
        {
            if (amount == 0)
                return 0;

            var res = string.Empty;
            void dfs(List<int> cur, double curSum, int cursor)
            {
                if (curSum == amount)
                {
                    string s = string.Empty;
                    foreach (var item in cur)
                    {
                        s += item.ToString();
                    }

                    if (res.Length > s.Length || res.Length == 0)
                    {
                        res = s;
                    }
                    return;
                }

                if (curSum > amount)
                    return;

                for (int i = cursor; i < coins.Length; ++i)
                {
                    cur.Add(coins[i]);
                    dfs(cur, curSum + coins[i], i);
                    cur.RemoveAt(cur.Count - 1);
                }
            }

            dfs(new List<int>(), 0, 0);

            return res.Length == 0 ? -1 : res.Length;
        }

        public int CoinChangeBoTopDown(int[] coins, int amount)
        {
            var dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = amount + 1;
            }
            dp[0] = 0;

            for (int i = 1; i < amount + 1; ++i)
            {
                foreach (var c in coins)
                {
                    if (i - c >= 0)
                    {
                        dp[i] = Math.Min(dp[i], 1 + dp[i - c]);
                    }
                }
            }

            if (dp[amount] != amount + 1)
            {
                return dp[amount];
            }
            else
            {
                return -1;
            }
        }

        public int CoinChangeBruteForce(int[] coins, int amount)
        {
            if (amount < 0)
                return -1;
            if (amount == 0)
                return 0;
            int cc = -1;
            for (int i = 0; i < coins.Length; i++)
            {
                int coin = CoinChangeBruteForce(coins, amount - coins[i]);
                if (coin >= 0)
                {
                    cc = cc < 0 ? coin + 1 : Math.Min(cc, coin + 1);
                }
            }
            return cc;
        }

        public int coinChangeMemoised(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = -1;
            }

            int result = recursion(amount);
            return result == int.MaxValue ? -1 : result;

            int recursion(int n)
            {
                if (n == 0)
                    return 0;

                int res = int.MaxValue;
                for (int i = 0; i < coins.Length; i++)
                {
                    int temp = 0;
                    if (n - coins[i] >= 0)
                    {
                        if (dp[n - coins[i]] != -1)
                        {
                            temp = dp[n - coins[i]];
                        }
                        else
                        {
                            temp = recursion(n - coins[i]);
                        }

                        if (temp != int.MaxValue)
                        {
                            res = Math.Min(res, temp + 1);
                        }
                    }
                }

                return dp[n] = res;
            }
        }
    }
}

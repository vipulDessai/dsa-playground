namespace learning_dsa_csharp._13_1_d_dynamic_programming._021_stone_game_ii
{
    internal class MySoln
    {
        public int StoneGameII(int[] piles)
        {
            if (piles == null || piles.Length == 0)
                return 0;

            int n = piles.Length;
            int[] sums = new int[n];
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }

            int dfs(int i, int m)
            {
                if (i == n)
                    return 0;
                if (2 * m >= n - i)
                {
                    return sums[i];
                }

                if (dp[i][m] != 0)
                    return dp[i][m];

                int min = int.MaxValue; // the min value the next player can get
                for (int j = 1; j <= 2 * m; ++j)
                {
                    min = Math.Min(min, dfs(i + j, Math.Max(m, j)));
                }

                dp[i][m] = sums[i] - min; // max stones = all the left stones - the min stones next player can get
                return dp[i][m];
            }

            sums[n - 1] = piles[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                sums[i] = sums[i + 1] + piles[i]; // the sum from piles[i] to the end
            }

            var res = dfs(0, 1);
            return res;
        }
    }
}

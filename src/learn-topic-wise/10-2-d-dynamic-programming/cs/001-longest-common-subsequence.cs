namespace learning_dsa_csharp._14_2_d_dynamic_programming._001_longest_common_subsequence
{
    internal class Solution_Others_Brute_to_Bottoms_Up
    {
        private int[,] dp;

        public int LongestCommonSubsequence(string text1, string text2)
        {
            // brute force
            // return lcsBruteForce(text1, text2, 0, 0);

            // dp = new int[text1.Length, text2.Length];
            // return lcsMemoisedTopDownDp(text1, text2, 0, 0);

            dp = new int[text1.Length + 1, text2.Length + 1];
            return lcsIterativeBottomUpDp(text1, text2);
        }

        private int lcsBruteForce(string t1, string t2, int i, int j)
        {
            if (i == t1.Length || j == t2.Length)
                return 0;

            if (t1[i] == t2[j])
                return 1 + lcsBruteForce(t1, t2, i + 1, j + 1);
            else
            {
                return Math.Max(lcsBruteForce(t1, t2, i + 1, j), lcsBruteForce(t1, t2, i, j + 1));
            }
        }

        private int lcsMemoisedTopDownDp(string t1, string t2, int i, int j)
        {
            if (i == t1.Length || j == t2.Length)
                return 0;

            if (dp[i, j] != 0)
                return dp[i, j];

            if (t1[i] == t2[j])
                return dp[i, j] = 1 + lcsMemoisedTopDownDp(t1, t2, i + 1, j + 1);
            else
            {
                return dp[i, j] = Math.Max(
                    lcsMemoisedTopDownDp(t1, t2, i + 1, j),
                    lcsMemoisedTopDownDp(t1, t2, i, j + 1)
                );
            }
        }

        private int lcsIterativeBottomUpDp(string t1, string t2)
        {
            for (int i = 1; i <= t1.Length; i++)
            {
                for (int j = 1; j <= t2.Length; j++)
                {
                    if (t1[i - 1] == t2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[t1.Length, t2.Length];
        }
    }

    internal class MySoln_brute_plus_dp
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            string sMin,
                sMax;
            if (text1.Length > text2.Length)
            {
                sMax = text1;
                sMin = text2;
            }
            else
            {
                sMax = text2;
                sMin = text1;
            }

            int n = sMin.Length;
            int m = sMax.Length;

            int[,] dp = new int[m, n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    dp[i, j] = -1;
                }
            }

            int dfs(int i, int j)
            {
                if (j == n)
                {
                    return 0;
                }

                if (i == m)
                {
                    return 0;
                }

                if (dp[i, j] != -1)
                    return dp[i, j];

                if (sMax[i] == sMin[j])
                {
                    dp[i, j] = 1 + dfs(i + 1, j + 1);
                    return dp[i, j];
                }
                else
                {
                    dp[i, j] = Math.Max(dfs(i + 1, j), dfs(i, j + 1));
                    return dp[i, j];
                }
            }

            return dfs(0, 0);
        }
    }

    internal class MySoln_Bottoms_up
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            string sMin,
                sMax;
            if (text1.Length > text2.Length)
            {
                sMax = text1;
                sMin = text2;
            }
            else
            {
                sMax = text2;
                sMin = text1;
            }

            int n = sMin.Length;
            int m = sMax.Length;

            int[,] dp = new int[m, n];

            dp[0, 0] = sMax[0] == sMin[0] ? 1 : 0;
            for (int i = 1; i < n; ++i)
            {
                dp[0, i] = sMax[0] == sMin[i] ? 1 : Math.Max(0, dp[0, i - 1]);
            }

            int rMax = dp[0, 0];
            for (int i = 1; i < m; ++i)
            {
                dp[i, 0] = sMax[i] == sMin[0] ? 1 : dp[i - 1, 0];
                for (int j = 1; j < n; ++j)
                {
                    dp[i, j] =
                        sMax[i] == sMin[j]
                            ? 1 + dp[i - 1, j - 1]
                            : Math.Max(dp[i, j - 1], dp[i - 1, j]);
                }

                rMax = Math.Max(rMax, dp[i, n - 1]);

                if (rMax == n)
                {
                    return rMax;
                }
            }

            return rMax;
        }
    }
}

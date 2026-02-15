namespace learning_dsa_csharp._14_2_d_dynamic_programming._012_valid_parenthesis_string
{
    internal class OthersSoln_brute
    {
        public bool CheckValidString(string s)
        {
            int n = s.Length;

            bool dfs(int i, int oB)
            {
                if (i == n)
                    return oB == 0;

                if (s[i] == '*')
                {
                    bool res = dfs(i + 1, oB + 1);
                    if (oB > 0)
                        res |= dfs(i + 1, oB - 1);
                    res |= dfs(i + 1, oB);

                    return res;
                }
                else
                {
                    if (s[i] == '(')
                    {
                        return dfs(i + 1, oB + 1);
                    }
                    else
                    {
                        if (oB > 0)
                        {
                            return dfs(i + 1, oB - 1);
                        }
                    }
                }

                return false;
            }

            return dfs(0, 0);
        }
    }

    internal class OthersSoln_dp
    {
        public bool CheckValidString(string s)
        {
            int n = s.Length;

            Dictionary<(int, int), bool> m = [];

            bool dfs(int i, int oB)
            {
                if (i == n)
                    return oB == 0;

                if (m.ContainsKey((i, oB)))
                    return m[(i, oB)];

                bool res = false;
                if (s[i] == '*')
                {
                    res = dfs(i + 1, oB + 1);
                    if (oB > 0)
                        res |= dfs(i + 1, oB - 1);
                    res |= dfs(i + 1, oB);
                }
                else
                {
                    if (s[i] == '(')
                    {
                        res = dfs(i + 1, oB + 1);
                    }
                    else
                    {
                        if (oB > 0)
                        {
                            res = dfs(i + 1, oB - 1);
                        }
                    }
                }

                m[(i, oB)] = res;
                return res;
            }

            return dfs(0, 0);
        }
    }

    internal class OthersSoln_dp_tabulation
    {
        public bool CheckValidString(string s)
        {
            int n = s.Length;
            bool[][] dp = new bool[n + 1][];
            for (int i = 0; i < n + 1; ++i)
            {
                dp[i] = new bool[n + 1];
                Array.Fill(dp[i], false);
            }
            dp[n][0] = true;

            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = 0; j < n; j++)
                {
                    bool res = false;
                    if (s[i] == '*')
                    {
                        res |= dp[i + 1][j + 1];
                        if (j > 0)
                            res |= dp[i + 1][j - 1];
                        res |= dp[i + 1][j];
                    }
                    else
                    {
                        if (s[i] == '(')
                        {
                            res = dp[i + 1][j + 1];
                        }
                        else
                        {
                            if (j > 0)
                            {
                                res = dp[i + 1][j - 1];
                            }
                        }
                    }

                    dp[i][j] = res;
                }
            }

            return dp[0][0];
        }
    }
}

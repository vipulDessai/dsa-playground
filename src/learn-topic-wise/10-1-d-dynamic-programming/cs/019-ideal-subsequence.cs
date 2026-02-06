namespace learning_dsa_csharp._13_1_d_dynamic_programming._019_ideal_subsequence
{
    // solution requires segment tree
    internal class MySoln
    {
        // gets TLE, even after memoisation
        public int LongestIdealString(string s, int k)
        {
            int n = s.Length;

            Dictionary<(int, int), int> dp = new();

            int dfs(int i, int prevI)
            {
                if (i < n)
                {
                    if (dp.ContainsKey((i, prevI)))
                        return dp[(i, prevI)];

                    if (prevI == -1 || Math.Abs(s[prevI] - s[i]) <= k)
                    {
                        dp[(i, prevI)] = Math.Max(1 + dfs(i + 1, i), dfs(i + 1, prevI));
                    }
                    else
                    {
                        dp[(i, prevI)] = dfs(i + 1, prevI);
                    }

                    return dp[(i, prevI)];
                }
                else
                {
                    return 0;
                }
            }

            return dfs(0, -1);
        }
    }
}

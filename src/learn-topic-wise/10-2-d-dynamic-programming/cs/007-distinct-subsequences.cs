using System.Collections.Generic;

namespace learning_dsa_csharp._14_2_d_dynamic_programming._007_distinct_subsequences
{
    public class Solution
    {
        int[,] dp;
        string str = string.Empty;
        string tag = string.Empty;

        public int NumDistinct(string s, string t)
        {
            str = s;
            tag = t;

            dp = new int[str.Length, tag.Length];
            for (int i = 0; i < str.Length; ++i)
            {
                for (int j = 0; j < tag.Length; ++j)
                {
                    dp[i, j] = -1;
                }
            }

            List<char> chars = new List<char>();

            return dfs(chars, 0, 0);
        }

        private int dfs(List<char> cur, int cIndex, int tIndex)
        {
            if (tIndex == tag.Length)
            {
                return 1;
            }
            ;

            // check if the current char is present in the remaining tag string
            // this has to be done before checking the dp array, otherwise
            // incorrect combination from the dp will be returned
            while (cIndex < str.Length && str[cIndex] != tag[tIndex])
            {
                cIndex++;
            }

            if (
                tIndex >= tag.Length
                || cIndex >= str.Length
                || str.Length - cIndex < tag.Length - tIndex
            )
            {
                return 0;
            }

            if (dp[cIndex, tIndex] != -1)
            {
                return dp[cIndex, tIndex];
            }

            cur.Add(str[cIndex]);

            var count = dfs(cur, cIndex + 1, tIndex + 1);

            cur.RemoveAt(cur.Count - 1);

            count += dfs(cur, cIndex + 1, tIndex);

            dp[cIndex, tIndex] = count;
            return count;
        }
    }
}

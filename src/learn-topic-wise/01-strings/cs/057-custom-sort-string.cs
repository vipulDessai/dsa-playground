using System.Text;

namespace learning_dsa_csharp._01_strings_arrays_hash._057_custom_sort_string
{
    internal class MySoln
    {
        public string CustomSortString(string order, string s)
        {
            int n = s.Length;

            int[] dp = new int[26];
            for (int i = 0; i < n; ++i)
            {
                ++dp[s[i] - 'a'];
            }

            StringBuilder sb = new();
            for (int i = 0; i < order.Length; ++i)
            {
                if (dp[order[i] - 'a'] > 0)
                {
                    while (dp[order[i] - 'a'] > 0)
                    {
                        sb.Append(order[i]);
                        --dp[order[i] - 'a'];
                    }
                }
            }

            for (int i = 0; i < 26; ++i)
            {
                if (dp[i] > 0)
                {
                    for (int j = 0; j < dp[i]; ++j)
                    {
                        char c = (char)(i + 'a');
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
        }
    }
}

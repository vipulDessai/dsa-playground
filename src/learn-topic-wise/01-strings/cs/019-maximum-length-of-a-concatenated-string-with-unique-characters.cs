namespace learning_dsa_csharp._01_strings_arrays_hash._025_max_length_of_a_concatenated_str_with_unique_chars
{
    // https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters
    internal class MySoln_DFS
    {
        public int MaxLength(IList<string> arr)
        {
            Dictionary<string, int[]> m = new Dictionary<string, int[]>();
            List<string> uArr = new List<string>();
            foreach (var s in arr)
            {
                int sLen = s.Length;

                int[] c = new int[26];
                Array.Fill(c, 0);

                bool sUnique = true;
                for (int i = 0; i < sLen; ++i)
                {
                    c[s[i] - 'a']++;

                    if (c[s[i] - 'a'] == 2)
                    {
                        sUnique = false;
                        break;
                    }
                }

                if (sUnique)
                {
                    uArr.Add(s);
                    m.Add(s, c);
                }
            }

            int n = uArr.Count;
            int[] dp = new int[n];
            int dfs(int i, int[] prev)
            {
                if (i == n)
                {
                    return 0;
                }

                string s = uArr[i];
                int[] sC = m[s];

                bool sConcat = true;
                for (int j = 0; j < 26; ++j)
                {
                    if (sC[j] > 0 && prev[j] > 0)
                    {
                        sConcat = false;
                        break;
                    }
                }

                if (sConcat)
                {
                    int[] newC = new int[26];
                    for (int j = 0; j < 26; ++j)
                    {
                        newC[j] = sC[j] + prev[j];
                    }

                    return Math.Max(s.Length + dfs(i + 1, newC), dfs(i + 1, prev));
                }
                else
                {
                    return dfs(i + 1, prev);
                }
            }

            int[] initialCharCount = new int[26];
            Array.Fill(initialCharCount, 0);
            return dfs(0, initialCharCount);
        }
    }

    internal class Soln_Bit_manipulation
    {
        public int MaxLength(List<string> arr)
        {
            List<int> dp = new List<int>() { 0 };
            int res = 0;
            foreach (var s in arr)
            {
                int a = 0,
                    dup = 0;
                foreach (char c in s.ToCharArray())
                {
                    dup |= a & (1 << (c - 'a'));
                    a |= 1 << (c - 'a');
                }

                if (dup > 0)
                    continue;

                for (int i = dp.Count - 1; i >= 0; i--)
                {
                    if ((dp[i] & a) > 0)
                        continue;

                    dp.Add(dp[i] | a);

                    res = Math.Max(res, Bit32.BitCount(dp[i] | a));
                }
            }
            return res;
        }
    }
}

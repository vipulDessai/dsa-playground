using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._01_strings_arrays_hash._011_largest_substring_btw_2_equal_chars
{
    internal class Solution
    {
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            int n = s.Length;
            int res = -1;
            Dictionary<char, int> h = new Dictionary<char, int>();
            for (int i = 0; i < n; i++)
            {
                if (h.ContainsKey(s[i]))
                {
                    int prevIndex = h[s[i]];
                    int curLen = i - prevIndex - 1;
                    res = Math.Max(res, curLen);
                }
                else
                {
                    h[s[i]] = i;
                }
            }

            return res;
        }
    }
}

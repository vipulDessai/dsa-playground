using System;

namespace learning_dsa_csharp._01_strings_arrays_hash._009_min_changes_to_make_alternating_binary_str
{
    internal class Solution
    {
        public int MinOperations(string s)
        {
            int c1 = 1;
            char prev1 = s[0] == '0' ? '1' : '0';
            // count operation by flipping the 1st char
            for (int i = 1; i < s.Length; i++)
            {
                char cur = s[i];
                if (prev1 == cur)
                {
                    c1++;
                    cur = s[i] == '0' ? '1' : '0';
                }

                prev1 = cur;
            }

            // count operations by skipping the flip of 1st char
            int c2 = 0;
            int prev2 = s[0];
            for (int i = 1; i < s.Length; i++)
            {
                char cur = s[i];
                if (prev2 == cur)
                {
                    c2++;
                    cur = s[i] == '0' ? '1' : '0';
                }

                prev2 = cur;
            }

            return Math.Min(c1, c2);
        }
    }
}

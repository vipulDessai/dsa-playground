// export const url = "[](https://leetcode.com/problems/minimum-number-of-moves-to-make-palindrome/description/)"

namespace learning_dsa_csharp._01_strings_arrays_hash._001_min_move_to_make_palindrome
{
    internal class Solution
    {
        public int MinMovesToMakePalindrome(string s)
        {
            char[] cStr = s.ToCharArray();

            int l = 0;
            int r = cStr.Length - 1;

            int count = 0;
            int center_i = -1;

            while (l < r)
            {
                if (cStr[l] == cStr[r])
                {
                    l++;
                    r--;
                    continue;
                }

                int k = l + 1;
                for (; k < r; k++)
                {
                    if (cStr[k] == cStr[r])
                    {
                        break;
                    }
                }

                if (k == r)
                {
                    center_i = r;
                    r--;
                    continue;
                }

                for (int j = k; j > l; j--)
                {
                    cStr = SwapChar(cStr, j, j - 1);
                    count++;
                }

                l++;
                r--;
            }

            if (center_i != -1)
            {
                count += (center_i - cStr.Length / 2);
            }

            return count;
        }

        public char[] SwapChar(char[] s, int i1, int i2)
        {
            char t = s[i1];
            s[i1] = s[i2];
            s[i2] = t;

            return s;
        }
    }
}

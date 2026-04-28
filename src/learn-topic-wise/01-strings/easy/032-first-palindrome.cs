// https://leetcode.com/problems/find-first-palindromic-string-in-the-array/
namespace learning_dsa_csharp._01_strings_arrays_hash._032_first_palindrome
{
    internal class MySoln
    {
        public string FirstPalindrome(string[] words)
        {
            bool isPali(int l, int r, string w)
            {
                int n = w.Length;
                while (l >= 0 && r < n)
                {
                    if (w[l] != w[r])
                    {
                        return false;
                    }

                    l--;
                    r++;
                }

                return true;
            }

            int wLen = words.Length;
            for (int i = 0; i < wLen; ++i)
            {
                string cur = words[i];

                if (cur.Length == 2)
                {
                    if (cur[0] == cur[1])
                        return cur;
                }
                else
                {
                    int l,
                        r;
                    if (cur.Length % 2 == 0)
                    {
                        l = (cur.Length / 2) - 1;
                        r = l + 1;
                    }
                    else
                    {
                        l = (cur.Length / 2) - 1;
                        r = (cur.Length / 2) + 1;
                    }
                    if (isPali(l, r, cur))
                    {
                        return cur;
                    }
                }
            }

            return "";
        }
    }
}

// https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends/description/
namespace learning_dsa_csharp._02_two_pointers._005_minimum_length_of_string_after_deleting_similar_ends
{
    internal class MySoln
    {
        public int MinimumLength(string s)
        {
            int n = s.Length;

            int l = 0;
            int r = n - 1;

            while (l < r && s[l] == s[r])
            {
                while (s[l] == s[r] && l != r)
                {
                    ++l;
                }
                --l;
                while (s[l] == s[r] && l != r)
                {
                    --r;
                }

                ++l;
            }

            return r - l + 1;
        }
    }
}

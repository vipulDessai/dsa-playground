// url = [Find the Longest Semi-Repetitive Substring](https://leetcode.com/problems/find-the-longest-semi-repetitive-substring/)

namespace learning_dsa_csharp._03_sliding_window._019_find_longest_semi_repetitive_substring
{
    interface ILongestSemiRepetitive
    {
        int LongestSemiRepetitiveSubstring(string s);
    }

    internal class MySoln: ILongestSemiRepetitive
    {
        public int LongestSemiRepetitiveSubstring(string s)
        {
            return 0;
        }
    }

    // https://leetcode.com/problems/find-the-longest-semi-repetitive-substring/solutions/3622843/java-sliding-window-approach-easy-to-understand
    internal class OthersSoln: ILongestSemiRepetitive
    {
        public int LongestSemiRepetitiveSubstring(string s)
        {
            int l = 0,
                r = 0;
            int count = 0;
            int ans = 1;
            while (r < s.Length - 1 && l <= r)
            {
                r++;
                if (s[r] == s[r - 1])
                    count++;

                while (count >= 2)
                {
                    l++;
                    if (s[l] == s[l - 1])
                        count--;
                }

                ans = Math.Max(ans, r - l + 1);
            }

            return ans;
        }
    }

    internal class Execute
    {
        public static void Main(String[] args)
        {
            ILongestSemiRepetitive soln = new MySoln();
            var res = soln.LongestSemiRepetitiveSubstring("00110");

            soln = new OthersSoln();
            res = soln.LongestSemiRepetitiveSubstring("00110");

            Console.WriteLine(res);
        }
    }
}
// https://leetcode.com/problems/word-break-ii

using System.Collections.Generic;

namespace learning_dsa_csharp._01_strings_arrays_hash._003_word_break_2
{
    internal class Solution
    {
        List<string> res = new List<string>();
        List<List<int>> starts = new List<List<int>>();
        string s = string.Empty;

        public IList<string> WordBreak(string str, IList<string> wordDict)
        {
            s = str;

            for (int i = 0; i < s.Length + 1; ++i)
            {
                starts.Add(null);
            }

            starts[0] = new List<int>() { 0 };
            for (int i = 1; i <= s.Length; ++i)
            {
                foreach (var w in wordDict)
                {
                    if ((i - w.Length >= 0) && s.Substring(i - w.Length, w.Length) == w)
                    {
                        // for the cases where the complete string do NOT form
                        // a sentence
                        if (starts[i - w.Length] == null)
                            continue;

                        if (starts[i] == null)
                        {
                            starts[i] = new List<int>();
                        }

                        starts[i].Add(i - w.Length);
                    }
                }
            }

            res = new List<string>();
            if (starts[s.Length] == null)
                return res;

            dfs("", s.Length);

            return res;
        }

        private void dfs(string path, int end)
        {
            if (end == 0)
            {
                res.Add(path.Substring(1));
                return;
            }

            foreach (int start in starts[end])
            {
                string word = s.Substring(start, end - start);
                dfs(" " + word + path, start);
            }
        }
    }
}

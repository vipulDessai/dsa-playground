// https://leetcode.com/problems/maximum-score-words-formed-by-letters/description
namespace learning_dsa_csharp._10_backtracking._012_maximum_scrore_words_formed_by_letters
{
    internal class MySoln
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            if (
                words == null
                || words.Length == 0
                || letters == null
                || letters.Length == 0
                || score == null
                || score.Length == 0
            )
                return 0;

            int[] count = new int[score.Length];
            foreach (char ch in letters)
            {
                count[ch - 'a']++;
            }

            return dfs(words, score, 0, count, []);
        }

        private int dfs(string[] words, int[] score, int i, int[] count, List<string> cur)
        {
            if (i >= words.Length)
                return 0;

            string curW = words[i];

            bool isValid = true;
            int r1 = 0;
            foreach (char ch in curW)
            {
                count[ch - 'a']--;
                r1 += score[ch - 'a'];

                if (count[ch - 'a'] < 0)
                    isValid = false;
            }

            if (isValid)
            {
                cur.Add(curW);
                r1 += dfs(words, score, i + 1, count, cur);

                cur.RemoveAt(cur.Count - 1);
                foreach (char ch in curW)
                {
                    count[ch - 'a']++;
                }

                // TODO: not working for producing [dad, good]
                int r2 = dfs(words, score, i + 1, count, cur);

                return Math.Max(r1, r2);
            }
            else
            {
                return dfs(words, score, i + 1, count, cur);
            }
        }
    }

    internal class OthersSoln
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            if (
                words == null
                || words.Length == 0
                || letters == null
                || letters.Length == 0
                || score == null
                || score.Length == 0
            )
                return 0;

            int[] count = new int[score.Length];
            foreach (char ch in letters)
            {
                count[ch - 'a']++;
            }

            return dfs(words, count, score, 0);
        }

        int dfs(string[] words, int[] count, int[] score, int index)
        {
            int max = 0;
            for (int i = index; i < words.Length; i++)
            {
                int res = 0;
                bool isValid = true;
                foreach (char ch in words[i])
                {
                    count[ch - 'a']--;
                    res += score[ch - 'a'];
                    if (count[ch - 'a'] < 0)
                        isValid = false;
                }

                if (isValid)
                {
                    res += dfs(words, count, score, i + 1);
                    max = Math.Max(res, max);
                }

                foreach (char ch in words[i])
                {
                    count[ch - 'a']++;
                }
            }
            return max;
        }
    }
}

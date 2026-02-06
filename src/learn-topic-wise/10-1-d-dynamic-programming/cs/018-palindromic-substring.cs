namespace learning_dsa_csharp._13_1_d_dynamic_programming._018_palindromin_substring
{
    // TLE at 128/130
    // very bad approach, worse than a 2 for loop brute force
    // as the substrings are repeating
    internal class MySoln
    {
        public int CountSubstrings(string s)
        {
            int n = s.Length;

            int res = 0;

            HashSet<(int, int)> m = new HashSet<(int, int)>();
            bool isPal(int l, int r)
            {
                m.Add((l, r));
                while (l < r)
                {
                    if (s[l] != s[r])
                    {
                        return false;
                    }

                    l++;
                    --r;
                }

                res++;

                return true;
            }

            void dfs(int i)
            {
                for (int j = i; j < n; ++j)
                {
                    if (m.Contains((i, j)))
                        continue;

                    if (isPal(i, j))
                    {
                        dfs(j + 1);
                    }
                }
            }

            dfs(0);

            return res;
        }
    }

    // https://leetcode.com/problems/palindromic-substrings/solutions/4703811/interview-approach-3-approach-brute-force-expand-middle-dp
    internal class OthersSoln_similar_to_longest_palindrome
    {
        public int CountSubstrings(string s)
        {
            int n = s.Length;

            int palindromeCount(int l, int r)
            {
                int count = 0;
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    count++;

                    l--;
                    r++;
                }

                return count;
            }

            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                int even = palindromeCount(i, i + 1);
                int odd = palindromeCount(i - 1, i + 1);
                ans += even + odd + 1;
            }
            return ans;
        }
    }

    internal class OthersSoln_dp
    {
        public int CountSubstrings(string s)
        {
            int n = s.Length;
            bool[,] palindrome = new bool[n, n];
            int ans = 0;

            // every letter is a palindrome
            for (int i = 0; i < n; i++)
            {
                palindrome[i, i] = true;
                ans++;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    palindrome[i, i + 1] = true;
                    ans++;
                }
            }

            for (int len = 3; len <= n; len++)
            {
                for (int i = 0; i < n - len + 1; i++)
                {
                    if (s[i] == s[i + len - 1] && palindrome[i + 1, i + len - 2])
                    {
                        palindrome[i, i + len - 1] = true;
                        ans++;
                    }
                }
            }

            return ans;
        }
    }
}

namespace learning_dsa_csharp._13_1_d_dynamic_programming._006_decode_ways
{
    internal class Solution
    {
        public int NumDecodings_Bruteforce_Recursion(string s)
        {
            int n = s.Length;
            int[] dp = new int[n];

            for (int i = 0; i < n; ++i)
                dp[i] = -1;

            return recursion(0);

            int recursion(int i)
            {
                if (i == n)
                    return 1;

                if (s[i] == '0')
                    return 0;

                if (dp[i] != -1)
                    return dp[i];

                int res = recursion(i + 1);

                if (i < n - 1 && (s[i] == '1' || s[i] == '2' && s[i + 1] < '7'))
                    res += recursion(i + 2);

                return dp[i] = res;
            }
        }
    }
}

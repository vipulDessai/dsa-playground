// https://leetcode.com/problems/perfect-squares/
namespace learning_dsa_csharp._13_1_d_dynamic_programming._003_perfect_squares
{
    // TLE at some 522/588 for n = 6250
    internal class MySoln
    {
        public int NumSquares(int n)
        {
            List<int> pSqs = new List<int>();
            int c = 1;
            do
            {
                pSqs.Add(c * c);
                ++c;
            } while (c * c <= n);

            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
            int bfs(int i, int r)
            {
                if (i < 0)
                {
                    return int.MaxValue;
                }

                int curS = pSqs[i];

                if (r - curS == 0)
                {
                    return 1;
                }

                if (r - curS < 0)
                {
                    return int.MaxValue;
                }

                if (dp.ContainsKey((i, r)))
                {
                    return dp[(i, r)];
                }

                int r1 = int.MaxValue;
                for (int j = i; j >= 0; --j)
                {
                    int curR = bfs(j, r - curS);
                    if (curR != int.MaxValue)
                        curR += 1;

                    r1 = Math.Min(curR, r1);
                }

                int r2 = bfs(i - 1, r);

                dp[(i, r)] = Math.Min(r1, r2);
                return dp[(i, r)];
            }

            return bfs(pSqs.Count - 1, n);
        }
    }

    // solution based 1D coin change problem
    internal class FromCoinChangeSoln
    {
        public int NumSquares(int n)
        {
            List<int> pSqs = new List<int>();
            int c = 1;
            do
            {
                pSqs.Add(c * c);
                ++c;
            } while (c * c <= n);

            int[] dp = new int[n + 1];
            for (int i = 0; i < dp.Length; ++i)
            {
                dp[i] = -1;
            }

            int recursion(int n)
            {
                if (n == 0)
                    return 0;

                int res = int.MaxValue;
                for (int i = 0; i < pSqs.Count; i++)
                {
                    int temp = 0;
                    if (n - pSqs[i] >= 0)
                    {
                        if (dp[n - pSqs[i]] != -1)
                        {
                            temp = dp[n - pSqs[i]];
                        }
                        else
                        {
                            temp = recursion(n - pSqs[i]);
                        }

                        if (temp != int.MaxValue)
                        {
                            res = Math.Min(res, temp + 1);
                        }
                    }
                }

                return dp[n] = res;
            }

            return recursion(n);
        }
    }
}

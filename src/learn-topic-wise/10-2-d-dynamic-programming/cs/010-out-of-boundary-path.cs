namespace learning_dsa_csharp._14_2_d_dynamic_programming._010_out_of_boundary_path
{
    internal class MySoln
    {
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            if (maxMove == 0)
            {
                return 0;
            }

            long MOD = 1000000007;
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((startRow, startColumn));
            HashSet<(int, int)> h = new HashSet<(int, int)>() { (startRow, startColumn) };

            int[] yD = new int[] { -1, 1, 0, 0 };
            int[] xD = new int[] { 0, 0, -1, 1 };

            long t = 0;
            while (q.Count > 0)
            {
                int qLen = q.Count;

                for (int i = 0; i < qLen; ++i)
                {
                    var (r, c) = q.Dequeue();

                    if (r < 0 || c < 0 || r >= m || c >= n)
                    {
                        t++;
                    }
                    else
                    {
                        for (int j = 0; j < 4; ++j)
                        {
                            int curMoves = maxMove;
                            int nextR = r,
                                nextC = c;
                            while (curMoves > 0)
                            {
                                nextR += yD[j];
                                nextC += xD[j];

                                curMoves--;
                            }

                            if (!h.Contains((nextR, nextC)))
                            {
                                h.Add((nextR, nextC));
                                q.Enqueue((nextR, nextC));
                            }
                        }
                    }
                }
            }

            return (int)t;
        }
    }

    // https://leetcode.com/problems/out-of-boundary-paths/solutions/4627117/beats-100-with-proof-very-easy-to-understand-multiple-languages-supported
    public class Solution_recursion
    {
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            long MOD = 1000000007;

            long[,,] dp = new long[m, n, maxMove + 1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k <= maxMove; k++)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }

            long Helper(int maxMove, int x, int y)
            {
                if (x < 0 || x >= m || y < 0 || y >= n)
                    return 1;

                if (maxMove <= 0)
                    return 0;

                if (dp[x, y, maxMove] != -1)
                {
                    return dp[x, y, maxMove];
                }

                long res = 0;

                res = (res + Helper(maxMove - 1, x + 1, y)) % MOD;
                res = (res + Helper(maxMove - 1, x, y - 1)) % MOD;
                res = (res + Helper(maxMove - 1, x - 1, y)) % MOD;
                res = (res + Helper(maxMove - 1, x, y + 1)) % MOD;

                dp[x, y, maxMove] = res;

                return res;
            }

            return (int)Helper(maxMove, startRow, startColumn);
        }
    }
}

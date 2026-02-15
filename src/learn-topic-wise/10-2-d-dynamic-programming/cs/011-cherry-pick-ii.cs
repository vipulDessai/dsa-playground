namespace learning_dsa_csharp._14_2_d_dynamic_programming._011_cherry_pick_2
{
    internal class MySoln
    {
        public int CherryPickup(int[][] grid)
        {
            int[] dX = [-1, 0, 1];

            int rLen = grid.Length;
            int cLen = grid[0].Length;

            int[,,] dp = new int[rLen, cLen, cLen];
            for (int i = 0; i < rLen; ++i)
            {
                for (int j = 0; j < cLen; ++j)
                {
                    for (int k = 0; k < cLen; ++k)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }

            int dfs(int r, int c1, int c2)
            {
                if (c1 < 0 || c2 < 0 || c1 == cLen || c2 == cLen)
                {
                    return 0;
                }

                if (dp[r, c1, c2] != -1)
                {
                    return dp[r, c1, c2];
                }

                int cSum = 0;
                if (c1 == c2)
                {
                    cSum = grid[r][c1];
                }
                else
                {
                    cSum = grid[r][c1] + grid[r][c2];
                }

                int nR = r + 1;
                if (nR == rLen)
                {
                    return cSum;
                }

                int max = int.MinValue;
                for (int i = 0; i < 3; ++i)
                {
                    int nC1 = c1 + dX[i];
                    for (int j = 0; j < 3; ++j)
                    {
                        int nC2 = c2 + dX[j];
                        max = Math.Max(max, cSum + dfs(nR, nC1, nC2));
                    }
                }

                dp[r, c1, c2] = max;
                return max;
            }

            return dfs(0, 0, cLen - 1);
        }
    }
}

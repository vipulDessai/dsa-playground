namespace learning_dsa_csharp._11_graphs._016_path_with_max_gold
{
    internal class MySoln
    {
        public int GetMaximumGold(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int[] xD = [1, -1, 0, 0];
            int[] yD = [0, 0, 1, -1];

            int dfs(int r, int c)
            {
                if (r < 0 || c < 0 || r > n - 1 || c > m - 1 || grid[r][c] == 0 || grid[r][c] == -1)
                {
                    return 0;
                }

                int t = grid[r][c];

                // mark visited
                grid[r][c] = -1;
                int max = 0;
                for (int i = 0; i < 4; ++i)
                {
                    int nR = r + xD[i];
                    int nC = c + yD[i];
                    max = Math.Max(max, dfs(nR, nC));
                }
                grid[r][c] = t;

                return t + max;
            }

            int res = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (grid[i][j] != 0)
                        res = Math.Max(res, dfs(i, j));
                }
            }

            return res;
        }
    }
}

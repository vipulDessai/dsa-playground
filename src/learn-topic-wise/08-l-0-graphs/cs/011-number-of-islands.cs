// https://leetcode.com/problems/number-of-islands/description/
namespace learning_dsa_csharp._11_graphs._011_number_of_islands
{
    internal class MySoln
    {
        public int NumIslands(char[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int[] xD = [1, -1, 0, 0];
            int[] yD = [0, 0, 1, -1];

            void dfs(int r, int c)
            {
                if (
                    r < 0
                    || c < 0
                    || r > n - 1
                    || c > m - 1
                    || grid[r][c] == '0'
                    || grid[r][c] == 'x'
                )
                {
                    return;
                }

                grid[r][c] = 'x';

                for (int k = 0; k < 4; ++k)
                {
                    int nR = r + xD[k];
                    int nC = c + yD[k];

                    dfs(nR, nC);
                }
            }

            int res = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (grid[i][j] == '1')
                    {
                        ++res;
                        dfs(i, j);
                    }
                }
            }

            return res;
        }
    }
}

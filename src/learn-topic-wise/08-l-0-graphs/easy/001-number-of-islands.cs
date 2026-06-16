// [Number of Islands](https://leetcode.com/problems/number-of-islands/description/)

namespace learning_dsa_csharp._11_graphs._011_number_of_islands
{
    internal class Solution
    {
        private void dfs(char[][] grid, int r, int c)
        {
            grid[r][c] = 'T';

            int m = grid.Length, n = grid[0].Length;

            int[,] directions = new int[4, 2]
            {
                {-1, 0},
                {0, 1},
                {1, 0},
                {0, -1}
            };

            for (int i = 0; i < 4; ++i)
            {
                int nR = r + directions[i, 0], nC = c + directions[i, 1];

                if (nR < 0 || nR >= m || nC < 0 || nC >= n) continue;

                if (grid[nR][nC] != '1') continue;

                dfs(grid, nR, nC);
            }
        }

        public int NumIslands(char[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;

            int res = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == '1')
                    {
                        dfs(grid, i, j);

                        ++res;
                    }
                }
            }

            return res;
        }
    }

    class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new();

            char[][] grid = [
                ['1', '1', '1', '1', '0'],
                ['1', '1', '0', '1', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '0', '0', '0']
            ];

            var output = s.NumIslands(grid);

            Console.WriteLine(output);
        }
    }
}

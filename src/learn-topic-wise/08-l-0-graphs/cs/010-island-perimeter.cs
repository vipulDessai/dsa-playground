// https://leetcode.com/problems/island-perimeter
namespace learning_dsa_csharp._11_graphs._010_island_perimeter
{
    internal class MySoln
    {
        public int IslandPerimeter(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int[] xD = [1, -1, 0, 0];
            int[] yD = [0, 0, 1, -1];

            int dfs(int r, int c)
            {
                // if out of bound or the land touches water, then count it so +1
                if (r < 0 || c < 0 || r > n - 1 || c > m - 1 || grid[r][c] == 0)
                {
                    return 1;
                }

                if (grid[r][c] == -1)
                {
                    return 0;
                }

                grid[r][c] = -1;

                int res = 0;
                for (int i = 0; i < 4; ++i)
                {
                    int nR = r + xD[i];
                    int nC = c + yD[i];

                    res += dfs(nR, nC);
                }

                return res;
            }

            int c = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (grid[i][j] == 1)
                        c += dfs(i, j);
                }
            }

            return c;
        }
    }

    // other soln - https://leetcode.com/problems/island-perimeter/solutions/5039036/faster-lesser-2-methods-detailed-approach-counting-dfs-python-java-c
    internal class OthersSoln_iterative
    {
        public int IslandPerimeter(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;

            int pC = 0;
            for (int r = 0; r < n; ++r)
            {
                for (int c = 0; c < m; ++c)
                {
                    if (grid[r][c] == 1)
                    {
                        pC += 4;

                        // check if above row item is land
                        if (r > 0 && grid[r - 1][c] == 1)
                            pC -= 2;

                        // check if previous col item is land
                        if (c > 0 && grid[r][c - 1] == 1)
                            pC -= 2;
                    }
                }
            }

            return pC;
        }
    }
}

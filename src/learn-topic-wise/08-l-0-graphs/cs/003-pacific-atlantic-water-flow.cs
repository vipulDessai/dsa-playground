using System.Collections.Generic;

namespace learning_dsa_csharp._11_graphs._003_pacific_atlantic_water_flow
{
    internal class Solution
    {
        int[][] h;
        int rLength;
        int cLength;

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            var pac = new HashSet<(int, int)>();
            var atl = new HashSet<(int, int)>();

            rLength = heights.Length;
            cLength = heights[0].Length;

            h = heights;

            for (int c = 0; c < cLength; c++)
            {
                dfs(0, c, pac, h[0][c]);
                dfs(rLength - 1, c, atl, h[rLength - 1][c]);
            }

            for (int r = 0; r < rLength; r++)
            {
                dfs(r, 0, pac, h[r][0]);
                dfs(r, cLength - 1, atl, h[r][cLength - 1]);
            }

            var res = new List<IList<int>>();
            for (int r = 0; r < rLength; r++)
            {
                for (int c = 0; c < cLength; c++)
                {
                    if (pac.Contains((r, c)) && atl.Contains((r, c)))
                    {
                        res.Add(new List<int>() { r, c });
                    }
                }
            }
            return res;
        }

        private void dfs(int r, int c, HashSet<(int, int)> visit, int prevHeight)
        {
            if (
                visit.Contains((r, c))
                || r < 0
                || c < 0
                || r == rLength
                || c == cLength
                || h[r][c] < prevHeight
            )
            {
                return;
            }

            visit.Add((r, c));

            dfs(r + 1, c, visit, h[r][c]);
            dfs(r - 1, c, visit, h[r][c]);
            dfs(r, c + 1, visit, h[r][c]);
            dfs(r, c - 1, visit, h[r][c]);
        }
    }
}

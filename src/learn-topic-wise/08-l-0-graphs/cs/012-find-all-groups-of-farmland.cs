// https://leetcode.com/problems/find-all-groups-of-farmland/description/
namespace learning_dsa_csharp._11_graphs._012_find_all_groups_of_farmland
{
    internal class MySoln
    {
        public int[][] FindFarmland(int[][] land)
        {
            int n = land.Length;
            int m = land[0].Length;

            int dfsCol(int r, int c)
            {
                if (c > m - 1 || land[r][c] == 0)
                {
                    return c - 1;
                }

                return dfsCol(r, c + 1);
            }

            int dfsRow(int r, int c)
            {
                if (r > n - 1 || land[r][c] == 0)
                {
                    return r - 1;
                }

                return dfsRow(r + 1, c);
            }

            List<int[]> res = new List<int[]>();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (land[i][j] == 1)
                    {
                        int mC = dfsCol(i, j);
                        int mR = dfsRow(i, j);

                        // mark the land as visited
                        for (int k = i; k <= mR; ++k)
                        {
                            for (int l = j; l <= mC; ++l)
                            {
                                land[k][l] = -1;
                            }
                        }

                        res.Add([i, j, mR, mC]);
                    }
                }
            }

            return res.ToArray();
        }
    }
}

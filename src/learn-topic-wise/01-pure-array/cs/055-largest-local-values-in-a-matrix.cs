// https://leetcode.com/problems/largest-local-values-in-a-matrix/
namespace learning_dsa_csharp._01_strings_arrays_hash._055_largest_local_values_in_a_matrix
{
    internal class MySoln
    {
        public int[][] LargestLocal(int[][] grid)
        {
            int n = grid.Length;
            int[][] res = new int[n - 2][];

            for (int i = 0; i < n - 2; ++i)
            {
                res[i] = new int[n - 2];
                for (int j = 0; j < n - 2; ++j)
                {
                    res[i][j] = GetMax(i, j);
                }
            }

            int GetMax(int r, int c)
            {
                int max = -1;
                for (int i = r; i < r + 3; ++i)
                {
                    for (int j = c; j < c + 3; ++j)
                    {
                        max = Math.Max(max, grid[i][j]);
                    }
                }

                return max;
            }

            return res;
        }
    }
}

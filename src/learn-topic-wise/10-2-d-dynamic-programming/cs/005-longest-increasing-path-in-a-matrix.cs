namespace learning_dsa_csharp._14_2_d_dynamic_programming._005_longest_increasing_path_in_a_matrix
{
    internal class Solution
    {
        public int LongestIncreasingPath(int[][] matrix)
        {
            int rLen = matrix.Length;
            int cLen = matrix[0].Length;

            int?[][] dp = new int?[rLen][];
            for (int i = 0; i < rLen; ++i)
            {
                dp[i] = new int?[cLen];
                for (int j = 0; j < cLen; ++j)
                {
                    dp[i][j] = null;
                }
            }

            int[] directionX = new[] { 1, -1, 0, 0 };
            int[] directionY = new[] { 0, 0, 1, -1 };

            int max = 0;
            for (int i = 0; i < rLen; ++i)
            {
                for (int j = 0; j < cLen; ++j)
                {
                    int curLen = dfs(i, j, -1);

                    if (curLen > max)
                        max = curLen;
                }
            }

            return max;

            int dfs(int r, int c, int cur)
            {
                // check out of bound
                if (r < 0 || c < 0 || r >= rLen || c >= cLen)
                    return 0;

                if (matrix[r][c] <= cur)
                    return 0;

                if (dp[r][c] != null)
                    return (int)dp[r][c];

                int _max = 0;
                for (int i = 0; i < 4; i++)
                {
                    int nextRow = r + directionX[i];
                    int nextCol = c + directionY[i];
                    int res = dfs(nextRow, nextCol, matrix[r][c]);

                    if (res > _max)
                        _max = res;
                }

                dp[r][c] = _max + 1;
                return (int)dp[r][c];
            }
        }
    }
}

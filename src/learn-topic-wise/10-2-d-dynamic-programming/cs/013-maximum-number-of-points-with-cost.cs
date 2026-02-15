namespace learning_dsa_csharp._14_2_d_dynamic_programming._013_maximum_number_of_points_with_cost
{
    // https://leetcode.com/problems/maximum-number-of-points-with-cost/solutions/5648191/easy-to-understand-recursion-tabular-tc-o-m-n-2-o-n-m
    internal class OthersSoln
    {
        public long MaxPoints(int[][] points)
        {
            int m = points.Length;
            int n = points[0].Length;

            long[] prev = new long[n];
            for (int i = 0; i < n; i++)
            {
                prev[i] = points[m - 1][i];
            }

            for (int i = m - 2; i >= 0; --i)
            {
                // left to right pass
                long[] leftMax = new long[n];
                leftMax[0] = prev[0];
                for (int j = 1; j < n; ++j)
                {
                    leftMax[j] = Math.Max(leftMax[j - 1] - 1, prev[j]);
                }

                // right to left pass
                long[] rightMax = new long[n];
                rightMax[n - 1] = prev[n - 1];
                for (int j = n - 2; j >= 0; --j)
                {
                    rightMax[j] = Math.Max(rightMax[j + 1] - 1, prev[j]);
                }

                long[] cur = new long[n];
                for (int j = 0; j < n; ++j)
                {
                    cur[j] = points[i][j] + Math.Max(leftMax[j], rightMax[j]);
                }

                prev = cur;
            }

            long res = 0;
            for (int i = 0; i < n; ++i)
            {
                res = Math.Max(res, prev[i]);
            }
            return res;
        }
    }
}

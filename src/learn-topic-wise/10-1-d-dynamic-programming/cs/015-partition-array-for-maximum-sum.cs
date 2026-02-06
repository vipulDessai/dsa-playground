namespace learning_dsa_csharp._13_1_d_dynamic_programming._015_partition_array_for_maximum_sum
{
    internal class OtherSoln_recursion_1
    {
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            int[] m = new int[arr.Length];
            int dfs(int i)
            {
                if (i == arr.Length)
                {
                    return 0;
                }

                if (m[i] != 0)
                {
                    return m[i];
                }

                int currMax = 0;
                int sumMax = 0;
                for (int j = 0; j < k; j++)
                {
                    // k decision to partition the array
                    int to = i + j;
                    if (to >= arr.Length)
                    {
                        // stop partition when we we reach end of the array
                        break;
                    }
                    currMax = Math.Max(currMax, arr[to]); // Running maximum of left partition array
                    int leftPartionSum = currMax * (j + 1); // sum of left partition
                    int rightPartionMaxSum = dfs(to + 1); // Max Sum of right partition - Sub problem
                    sumMax = Math.Max(sumMax, leftPartionSum + rightPartionMaxSum); // Since problem asks for largest sum, we track the largest sum of k decisions we are making in this loop.
                }

                m[i] = sumMax;
                return sumMax;
            }

            var r = dfs(0);
            return r;
        }
    }

    internal class OtherSoln_recursion_2
    {
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            int n = arr.Length;
            int[] m = new int[n];
            Array.Fill(m, -1);

            int dfs(int i)
            {
                if (i >= n)
                {
                    return 0;
                }

                if (m[i] != -1)
                {
                    return m[i];
                }

                int end = Math.Min(i + k, n);
                int len = 1;
                int sum = Int32.MinValue;
                int max = Int32.MinValue;
                for (int j = i; j < end; ++j)
                {
                    max = Math.Max(max, arr[j]);
                    int l = len * max;
                    int r = dfs(j + 1);

                    sum = Math.Max(sum, l + r);

                    len++;
                }

                m[i] = sum;
                return sum;
            }

            return dfs(0);
        }
    }
}

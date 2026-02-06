namespace learning_dsa_csharp._13_1_d_dynamic_programming._013_arithmetic_slices
{
    internal class Solution_Arithmetic_1
    {
        // solution - my brute force
        public int NumberOfArithmeticSlices_BigO_N_x_3(int[] nums)
        {
            if (nums.Length < 3)
                return 0;

            int n = 3;
            int c = 0;
            while (n <= nums.Length)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i + n - 1 < nums.Length)
                    {
                        int d = nums[i] - nums[i + 1];
                        bool isSubArr = true;
                        for (int j = i; j < i + n - 1; ++j)
                        {
                            if (nums[j] - nums[j + 1] != d)
                            {
                                isSubArr = false;
                                break;
                            }
                        }

                        if (isSubArr)
                        {
                            c++;
                        }
                    }
                }

                n++;
            }

            return c;
        }

        // solution - https://leetcode.com/problems/arithmetic-slices/solutions/1814371/c-easy-to-understand-full-explanation/
        public int NumberOfArithmeticSlices_BigO_N(int[] nums)
        {
            if (nums.Length < 3)
                return 0;

            int c = 0,
                ind = 0;
            int prevDiff = nums[1] - nums[0];
            for (int i = 1; i < nums.Length - 1; i++)
            {
                int curDiff = nums[i + 1] - nums[i];
                if (curDiff == prevDiff)
                {
                    ind++;
                }
                else
                {
                    ind = 0;
                }

                c += ind;
                prevDiff = curDiff;
            }

            return c;
        }
    }

    internal class Solution_Arithmetic_2
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            int n = nums.Length;
            if (n < 3)
                return 0;

            Dictionary<(int, int, int?), int> dp = new Dictionary<(int, int, int?), int>();
            List<List<int>> res = new List<List<int>>();
            int dfs(int i, int prevI, long? prevDiff, List<int> cur)
            {
                if (i >= n)
                {
                    if (cur.Count >= 3)
                        res.Add(cur);
                    return 0;
                }

                long? currDiff = prevI == -1 ? null : (long)nums[i] - nums[prevI];

                if (prevDiff == null || currDiff == prevDiff)
                {
                    List<int> _curr = new List<int>(cur) { nums[i] };
                    var r = Math.Max(
                        1 + dfs(i + 1, i, currDiff, _curr),
                        dfs(i + 1, prevI, prevDiff, new List<int>(cur))
                    );
                    return r;
                }
                else
                {
                    var r = dfs(i + 1, prevI, prevDiff, new List<int>(cur));
                    return r;
                }
            }

            var _r = dfs(0, -1, null, new List<int>());
            return res.Count;
        }
    }
}

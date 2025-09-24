// https://leetcode.com/problems/sum-of-all-subset-xor-totals/description
namespace learning_dsa_csharp._17_bit_manipulation._007_sum_of_all_subset_xor_totals
{
    internal class MySoln
    {
        public int SubsetXORSum(int[] nums)
        {
            int n = nums.Length;

            List<int[]> arr = new();
            void dfs(int i, List<int> cur)
            {
                if (i == n)
                {
                    arr.Add(cur.ToArray());
                }
                else
                {
                    cur.Add(nums[i]);
                    dfs(i + 1, cur);
                    cur.RemoveAt(cur.Count - 1);
                    dfs(i + 1, cur);
                }
            }

            dfs(0, []);

            int res = 0;
            n = arr.Count;
            for (int i = 0; i < n; ++i)
            {
                int[] cur = arr[i];
                int m = cur.Length;

                int xorRes = 0;
                for (int j = 0; j < m; ++j)
                {
                    xorRes ^= cur[j];
                }

                res += xorRes;
            }

            return res;
        }
    }
}

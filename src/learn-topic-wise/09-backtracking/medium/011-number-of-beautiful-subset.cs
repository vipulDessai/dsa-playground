// https://leetcode.com/problems/the-number-of-beautiful-subsets/
namespace learning_dsa_csharp._10_backtracking._011_number_of_beautiful_subset
{
    internal class MySoln_brute_backtracking
    {
        private bool IsSafe(List<int> cur, int k)
        {
            int m = cur.Count;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (Math.Abs(cur[j] - cur[i]) == k)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int BeautifulSubsets(int[] nums, int k)
        {
            int n = nums.Length;

            int res = 0;
            void dfs(int i, List<int> cur)
            {
                if (i >= n)
                {
                    if (IsSafe(cur, k))
                    {
                        ++res;
                    }
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

            return res - 1;
        }
    }

    internal class MySoln_optimized
    {
        private bool IsSafe(List<int> cur, int nxt, int k)
        {
            int m = cur.Count;
            for (int i = 0; i < m; ++i)
            {
                if (Math.Abs(nxt - cur[i]) == k)
                {
                    return false;
                }
            }

            return true;
        }

        public int BeautifulSubsets(int[] nums, int k)
        {
            int n = nums.Length;

            int res = 0;
            void dfs(int i, List<int> cur)
            {
                if (i >= n)
                {
                    ++res;
                }
                else
                {
                    if (IsSafe(cur, nums[i], k))
                    {
                        cur.Add(nums[i]);
                        dfs(i + 1, cur);
                        cur.RemoveAt(cur.Count - 1);
                    }

                    dfs(i + 1, cur);
                }
            }

            dfs(0, []);

            return res - 1;
        }
    }
}

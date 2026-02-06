// https://leetcode.com/problems/largest-divisible-subset/
namespace learning_dsa_csharp._13_1_d_dynamic_programming._017_largest_divisible_subset
{
    // really difficult to understand because in the problem we dont need counting, instead
    // we want the largest subset, so backtracking is ideal and easy
    internal class MySoln_with_index
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            int n = nums.Length;

            if (n == 1)
            {
                return nums;
            }

            Array.Sort(nums);

            Dictionary<(int, int), HashSet<int>> dp = new();

            HashSet<int> dfs(int i, int prevI)
            {
                if (i == n - 1)
                {
                    if (prevI != -1 && nums[i] % nums[prevI] == 0)
                    {
                        return [nums[prevI], nums[i]];
                    }

                    if (prevI != -1)
                        return [nums[prevI]];
                    else
                        return [];
                }

                if (dp.ContainsKey((i, prevI)))
                {
                    return dp[(i, prevI)];
                }

                if (prevI == -1 || nums[i] % nums[prevI] == 0)
                {
                    var r1 = dfs(i + 1, i);
                    var r2 = dfs(i + 1, prevI);

                    if (prevI != -1)
                        r1.Add(nums[prevI]);

                    if (r1.Count >= r2.Count)
                    {
                        dp[(i, prevI)] = r1;
                        return r1;
                    }
                    else
                    {
                        dp[(i, prevI)] = r2;
                        return r2;
                    }
                }
                else
                {
                    var r = dfs(i + 1, prevI);
                    r.Add(nums[prevI]);

                    dp[(i, prevI)] = r;
                    return r;
                }
            }

            return dfs(0, -1).ToList();
        }
    }

    internal class MySoln_backtracking
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            int n = nums.Length;

            if (n == 1)
            {
                return nums;
            }

            Array.Sort(nums);

            int[] m = new int[n + 1];
            Array.Fill(m, -1);

            List<int> res = new();
            void dfs(int i, List<int> cur)
            {
                if (i == n)
                {
                    if (res.Count < cur.Count)
                    {
                        res = cur.ToList();
                    }

                    return;
                }

                int prevI = cur.Count - 1;

                if (prevI == -1 || (cur.Count > m[i] && nums[i] % cur[prevI] == 0))
                {
                    m[i] = cur.Count;
                    cur.Add(nums[i]);
                    dfs(i + 1, cur);
                    cur.RemoveAt(cur.Count - 1);
                }

                dfs(i + 1, cur);
            }

            dfs(0, []);
            return res;
        }
    }

    // https://leetcode.com/problems/largest-divisible-subset/solutions/1578991/c-4-simple-solutions-w-detailed-explanation-optimizations-from-brute-force-to-dp
    // TODO -  form the largest subset after
    internal class OthersSoln_DP
    {
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            int n = nums.Length;

            List<int> m = new List<int>();
            List<int> succ = new List<int>();

            for (int i = 0; i < n; ++i)
            {
                m.Add(-1);
                succ.Add(int.MaxValue);
            }

            int dfs(int i)
            {
                if (i >= n)
                    return 0;

                if (m[i] != -1)
                    return m[i];

                for (int j = i + 1; j < n; ++j)
                {
                    if (nums[j] % nums[i] == 0)
                    {
                        var size = dfs(j);
                        if (m[i] < size + 1)
                        {
                            m[i] = size + 1;
                            succ[i] = j;
                        }
                    }
                }

                return m[i];
            }

            Array.Sort(nums);

            for (int i = 0; i < n; i++)
            {
                dfs(i);
            }

            int max = m[0];
            int sI = 0;
            for (int i = 1; i < n; ++i)
            {
                if (m[i] > max)
                {
                    max = m[i];
                    sI = i;
                }
            }

            List<int> res = new List<int>();
            for (int i = sI; i < n; i = succ[i])
            {
                res.Add(nums[i]);
            }

            return res;
        }
    }
}

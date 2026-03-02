// https://leetcode.com/problems/combination-sum-ii
namespace learning_dsa_csharp._10_backtracking._005_combination_sum_ii
{
    internal class MySoln
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            int n = candidates.Length;
            Array.Sort(candidates);

            IList<IList<int>> res = new List<IList<int>>();

            void dfs(List<int> cur, int curI, int curT)
            {
                if (curT == target)
                {
                    res.Add(cur.ToList());

                    return;
                }
                ;

                if (curT > target)
                {
                    return;
                }

                int prev = -1;
                for (int j = curI; j < n; ++j)
                {
                    int curCan = candidates[j];

                    if (curCan == prev)
                        continue;

                    cur.Add(curCan);
                    dfs(cur, j + 1, curT + curCan);
                    cur.RemoveAt(cur.Count - 1);

                    prev = curCan;
                }
            }

            dfs([], 0, 0);

            return res;
        }
    }
}

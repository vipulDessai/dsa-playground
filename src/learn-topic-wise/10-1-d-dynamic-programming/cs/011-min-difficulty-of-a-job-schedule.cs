using System;
using System.Collections.Generic;

namespace learning_dsa_csharp._13_1_d_dynamic_programming._011_min_difficulty_of_a_job_schedule
{
    internal class Solution
    {
        public int MinDifficulty_my_own_dp(int[] jobDifficulty, int d)
        {
            int n = jobDifficulty.Length;

            // just trying to form 1 combination
            // [123, 4, 5]  i.e form group and do recursion
            // and then will try to add
            // [1, 234, 5]  i.e. ignore 1st element as day 1 and do recursion for 2 days
            // [1, 2, 345]  i.e. same as above ^
            List<List<int>> printCombination(int begin, int day, int maxGrpLen)
            {
                if (day == 1)
                {
                    List<int> lastDayGrp = new List<int>();
                    for (int i = begin; i < n; i++)
                    {
                        lastDayGrp.Add(jobDifficulty[i]);
                    }
                    return new List<List<int>>() { lastDayGrp };
                }
                else
                {
                    List<int> curGroupByDay = new List<int>();
                    for (int i = begin; i < maxGrpLen; i++)
                    {
                        curGroupByDay.Add(jobDifficulty[i]);
                    }
                    List<List<int>> res = new List<List<int>>() { curGroupByDay };
                    var subGroups = printCombination(
                        begin + maxGrpLen,
                        day - 1,
                        n - (begin + maxGrpLen - (day - 2))
                    );
                    for (int i = 0; i < subGroups.Count; i++)
                    {
                        res.Add(subGroups[i]);
                    }

                    //curGroupByDay = new List<int>() { jobDifficulty[begin] };
                    //res.Add(curGroupByDay);

                    //subGroups = printCombination(begin + 1, g - 1);
                    //for (int i = 0; i < subGroups.Count; i++)
                    //{
                    //    res.Add(subGroups[i]);
                    //}

                    return res;
                }
            }

            var s = printCombination(0, d, n - (d - 1));

            return s.Count;
        }

        // solution - https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/solutions/2710942/easy-to-understand-java-detailed-solution-recursive-memoized/
        public int MinDifficulty_dp(int[] jobDifficulty, int d)
        {
            if (d > jobDifficulty.Length)
                return -1;

            if (d == jobDifficulty.Length)
            {
                int sum = 0;
                for (int i = 0; i < jobDifficulty.Length; ++i)
                {
                    sum += jobDifficulty[i];
                }
                return sum;
            }

            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
            int f(int start, int days)
            {
                if (days == 1)
                {
                    int res = 0;
                    while (start < jobDifficulty.Length)
                    {
                        res = Math.Max(res, jobDifficulty[start++]);
                    }
                    return res;
                }

                if (dp.ContainsKey((start, days)))
                {
                    return dp[(start, days)];
                }

                int max = 0;
                int r = int.MaxValue;

                for (int i = start; i <= jobDifficulty.Length - days; i++)
                {
                    max = Math.Max(max, jobDifficulty[i]);
                    r = Math.Min(r, max + f(i + 1, days - 1));
                }

                dp[(start, days)] = r;
                return r;
            }

            return f(0, d);
        }
    }
}

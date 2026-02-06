using System.Collections.Generic;

namespace learning_dsa_csharp._13_1_d_dynamic_programming._008_number_of_dice_rolls_with_target_sum
{
    internal class Solution
    {
        // if we start from dice 1 and for every dice iterate over the next dice till we get to the last dice
        // then all those iteration over the previous dice will be a waste if for that combination we are
        // not able to acheive the target sum
        // example
        // if target is 20
        // and if begin from dice 1 face 1 for 5 die and 6 faces
        // 1 1 1 1 1 6 -> wasted
        // ....
        // 1 1 2 4 6 6 -> till this loop we simply wasted the iterations
        // there we need to start from the last dice and compute what should be the
        // values for the previous die rolls
        //
        // below solution times out for many dice and many faces
        public int NumRollsToTarget_compute_from_dice_1(int n, int k, int target)
        {
            List<string> res = new List<string>();
            void dfs(int remaining, int i, string curCombination)
            {
                if (i == 1)
                {
                    res.Add($"{curCombination}{remaining}");
                    return;
                }

                for (int j = 1; j <= k; j++)
                {
                    if (remaining - j <= 0)
                    {
                        break;
                    }

                    dfs(remaining - j, i - 1, $"{curCombination}{j}");
                }
            }

            dfs(target, n, "");

            return res.Count;
        }

        public int NumRollsToTarget(int n, int k, int target)
        {
            int MOD = 1000000007;

            List<string> res = new List<string>();
            Dictionary<(int, int), long> dp = new Dictionary<(int, int), long>();
            long dfs(int remaining, int i, string curCombination)
            {
                if (i == 0)
                {
                    if (remaining == 0)
                    {
                        res.Add($"{curCombination}");

                        return 1;
                    }

                    return 0;
                }

                if (dp.ContainsKey((remaining, i)))
                {
                    return dp[(remaining, i)];
                }

                long count = 0;
                for (int j = 1; j <= k; ++j)
                {
                    count += (dfs(remaining - j, i - 1, $"{curCombination}{j}") % MOD);
                }

                dp[(remaining, i)] = count % MOD;
                return count % MOD;
            }

            return (int)dfs(target, n, "");
        }
    }
}

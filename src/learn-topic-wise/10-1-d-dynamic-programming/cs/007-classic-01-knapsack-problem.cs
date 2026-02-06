// problem - classic 0/1 knapsack problem
// solution - https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
namespace learning_dsa_csharp._13_1_d_dynamic_programming._007_classic_01_knapsack_problem
{
    internal class Solution
    {
        public int MaximumValue_using_dp(int bagCapacity, int[] profits, int[] weights)
        {
            int itemCount = profits.Length;
            Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();

            return knapSackClassicDp(bagCapacity, itemCount);

            int knapSackClassicDp(int w, int i)
            {
                if (w <= 0 || i == 0)
                {
                    return 0;
                }

                if (dp.ContainsKey((w, i)))
                {
                    return dp[(w, i)];
                }

                if (weights[i - 1] > w)
                {
                    dp[(w, i)] = knapSackClassicDp(w, i - 1);
                }
                else
                {
                    dp[(w, i)] = Math.Max(
                        profits[i - 1] + knapSackClassicDp(w - weights[i - 1], i - 1),
                        knapSackClassicDp(w, i - 1)
                    );
                }

                return dp[(w, i)];
            }
        }
    }
}

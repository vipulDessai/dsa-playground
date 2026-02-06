namespace learning_dsa_csharp._13_1_d_dynamic_programming._012_max_profit_in_job_scheduling
{
    internal class Solution
    {
        // TODO: fails at the AC 30/31, but the dp memoisation is incorrect
        public int JobScheduling_my_own(int[] startTime, int[] endTime, int[] profit)
        {
            List<(int, int, int)> sList = new List<(int, int, int)>();
            for (int i = 0; i < startTime.Length; ++i)
            {
                sList.Add((startTime[i], endTime[i], profit[i]));
            }

            sList.Sort(
                (a, b) =>
                {
                    var (a1, a2, a3) = a;
                    var (b1, b2, b3) = b;

                    return a1.CompareTo(b1);
                }
            );

            int[] dp = new int[startTime.Length];
            for (int i = 0; i < startTime.Length; ++i)
            {
                var (a1, a2, a3) = sList[i];
                startTime[i] = a1;
                endTime[i] = a2;
                profit[i] = a3;

                dp[i] = -1;
            }

            int maxProfit(int i)
            {
                if (i == startTime.Length - 1)
                {
                    return profit[i];
                }

                if (dp[i] != -1)
                {
                    return dp[i];
                }

                int eTime = endTime[i];

                int j = i + 1;
                while (j < startTime.Length)
                {
                    if (eTime <= startTime[j])
                    {
                        break;
                    }

                    j++;
                }

                int res;
                if (j == startTime.Length)
                {
                    res = Math.Max(profit[i], maxProfit(i + 1));
                }
                else
                {
                    res = Math.Max(profit[i] + maxProfit(j), maxProfit(i + 1));
                }

                dp[i] = res;
                return res;
            }

            return maxProfit(0);
        }
    }
}

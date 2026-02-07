namespace learning_dsa_csharp._15_greedy._004_most_profit_assigning_work
{
    internal class MySoln
    {
        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            int n = difficulty.Length;
            int m = worker.Length;

            List<(int, int)> dp = new List<(int, int)>();

            for (int i = 0; i < n; ++i)
            {
                dp.Add((difficulty[i], profit[i]));
            }

            dp.Sort(
                (a, b) =>
                {
                    var (a1, a2) = a;
                    var (b1, b2) = b;

                    return a1.CompareTo(b1);
                }
            );

            Array.Sort(worker);

            int l = 0,
                r = 0;
            int res = 0;
            while (l < m && r < n)
            {
                int curW = worker[l];

                while (r < n)
                {
                    var (cD, cP) = dp[r];
                    if (cD > curW && r - 1 != -1)
                    {
                        var (prevD, prevP) = dp[r - 1];

                        if (prevD <= curW)
                        {
                            res += prevP;
                        }

                        break;
                    }

                    ++r;
                }

                ++l;
            }

            return res;
        }
    }
}

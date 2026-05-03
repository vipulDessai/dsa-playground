namespace learning_dsa_csharp._05_binary_Search._004_capacity_to_ship_packages_within_d_days
{
    internal class OthersSoln
    {
        public int ShipWithinDays(int[] weights, int days)
        {
            bool feasible(int capacity)
            {
                int curDays = 1;
                int total = 0;

                foreach (var w in weights)
                {
                    total += w;
                    if (total > capacity) // too heavy, wait for the next day
                    {
                        total = w;
                        curDays += 1;

                        if (curDays > days) // cannot ship within D days
                            return false;
                    }
                }

                return true;
            }

            int BinarySearchTemplate(int[] array, int l, int r)
            {
                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if (feasible(mid))
                    {
                        r = mid;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                return l;
            }

            int max = int.MinValue,
                sum = 0;
            for (int i = 0; i < weights.Length; ++i)
            {
                max = Math.Max(max, weights[i]);
                sum += weights[i];
            }

            return BinarySearchTemplate(weights, max, sum);
        }
    }
}

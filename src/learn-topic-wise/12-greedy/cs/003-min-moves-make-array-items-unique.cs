namespace learning_dsa_csharp._15_greedy._003_min_moves_make_array_items_unique
{
    internal class MySoln
    {
        public int MinIncrementForUnique(int[] nums)
        {
            int n = nums.Length;

            Array.Sort(nums);

            int res = 0;
            int prev = nums[0];
            for (int i = 1; i < n; ++i)
            {
                if (nums[i] <= prev)
                {
                    int diff = prev - nums[i];

                    nums[i] += diff + 1;
                    res += diff + 1;
                }

                prev = nums[i];
            }

            return res;
        }
    }
}

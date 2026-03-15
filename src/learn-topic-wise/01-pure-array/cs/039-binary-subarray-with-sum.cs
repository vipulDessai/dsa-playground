namespace learning_dsa_csharp._01_strings_arrays_hash._039_binary_subarray_with_sum
{
    internal class MySoln
    {
        public int NumSubarraysWithSum(int[] nums, int goal)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = 1;

            int sum = 0,
                count = 0;
            foreach (int num in nums)
            {
                sum += num;

                int rem = sum - goal;
                if (map.ContainsKey(rem))
                {
                    count += map[rem];
                }

                if (!map.ContainsKey(sum))
                {
                    map[sum] = 0;
                }

                map[sum]++;
            }

            return count;
        }
    }
}

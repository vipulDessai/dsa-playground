namespace learning_dsa_csharp._01_strings_arrays_hash._027_divide_array_into_subarrays_with_min_cost_i
{
    // https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/
    internal class Soln
    {
        public int MinimumCost(int[] nums)
        {
            var l = nums.ToList();

            // because in the problem its asked to take first
            // elem as first value
            l.RemoveAt(0);
            l.Sort((a, b) => a.CompareTo(b));

            return nums[0] + l[0] + l[1];
        }
    }
}

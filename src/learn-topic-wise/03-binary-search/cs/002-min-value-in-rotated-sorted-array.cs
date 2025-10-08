namespace learning_dsa_csharp._05_binary_Search._002_min_value_in_rotated_sorted_array
{
    // https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
    internal class SolutionUsingPivotDirection
    {
        public int FindMin(int[] nums)
        {
            int n = nums.Length;
            int l = 0;
            int r = n - 1;

            while (l < r)
            {
                int m = ((l + r) - ((l + r) % 2)) / 2;
                if (nums[m] > nums[r])
                {
                    l = m + 1;
                }
                else
                {
                    r = m;
                }
            }

            return nums[l];
        }
    }
}

// [Find Minimum in Rotated Sorted Array](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/)

namespace learning_dsa_csharp._05_binary_Search._002_min_value_in_rotated_sorted_array
{
    interface IMinValueInRotatedSortedArray
    {
        int FindMin(int[] nums);
    }
    internal class Solution : IMinValueInRotatedSortedArray
    {
        public int FindMin(int[] nums)
        {
            int n = nums.Length;
            int l = 0;
            int r = n - 1;

            while (l < r)
            {
                // since integer division in C# already truncates toward zero, 
                // you don’t need Floor at all
                int m = l + (r - l) / 2;

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

    internal class Execute
    {
        public static void Main(string[] args)
        {
            IMinValueInRotatedSortedArray s = new Solution();

            var input = new int[] { 3, 4, 5, 1, 2 };
            Console.WriteLine(s.FindMin(input));

        }
    }
}


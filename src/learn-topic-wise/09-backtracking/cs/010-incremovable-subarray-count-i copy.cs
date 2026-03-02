using System.Collections.Generic;

// link - https://leetcode.com/contest/biweekly-contest-120/problems/count-the-number-of-incremovable-subarrays-i/
// You are given a 0-indexed array of positive integers nums.
// A subarray of nums is called incremovable if nums becomes strictly increasing on removing the subarray. For example, the subarray [3, 4] is an incremovable subarray of[5, 3, 4, 6, 7] because removing this subarray changes the array [5, 3, 4, 6, 7] to[5, 6, 7] which is strictly increasing.
// Return the total number of incremovable subarrays of nums.
// Note that an empty array is considered strictly increasing.
// A subarray is a contiguous non-empty sequence of elements within an array.

//Input: nums = [1, 2, 3, 4]
//Output: 10
//Explanation: The 10 incremovable subarrays are: [1], [2], [3], [4], [1,2], [2,3], [3,4], [1,2,3], [2,3,4], and[1, 2, 3, 4], because on removing any one of these subarrays nums becomes strictly increasing. Note that you cannot select an empty subarray.

//Input: nums = [6, 5, 7, 8]
//Output: 7
//Explanation: The 7 incremovable subarrays are: [5], [6], [5,7], [6,5], [5,7,8], [6,5,7] and[6, 5, 7, 8].
//It can be shown that there are only 7 incremovable subarrays in nums.

//Input: nums = [8, 7, 6, 6]
//Output: 3
//Explanation: The 3 incremovable subarrays are: [8,7,6], [7,6,6], and[8, 7, 6, 6].Note that[8, 7] is not an incremovable subarray because after removing [8,7] nums becomes[6, 6], which is sorted in ascending order but not strictly increasing.

namespace learning_dsa_csharp._10_backtracking._010_incremovable_subarray_count_i
{
    internal class Solution
    {
        public int IncremovableSubarrayCount(int[] nums)
        {
            void checkSubSets(int i)
            {
                List<int> l = new List<int>();
                for (int j = 0; j < nums.Length; j++)
                {
                    l.Add(nums[j]);
                    checkSubSets(j + 1);
                    l.RemoveAt(l.Count - 1);
                }
            }

            return 0;
        }
    }
}

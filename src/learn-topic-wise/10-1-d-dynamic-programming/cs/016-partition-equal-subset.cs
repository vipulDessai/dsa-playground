namespace learning_dsa_csharp._13_1_d_dynamic_programming._016_partition_equal_subset
{
    public class Solution
    {
        public bool CanPartition_backtracking_recursion(int[] nums)
        {
            IEnumerable<int> enemerableNums = nums;
            var totalSum = enemerableNums.Aggregate(
                0,
                (acc, cur) =>
                {
                    return acc + cur;
                }
            );

            if (totalSum % 2 != 0)
                return false;

            var targetSum = totalSum / 2;

            bool bactracking(int currSum, int i)
            {
                if (currSum > targetSum || i >= nums.Length)
                {
                    return false;
                }

                if (currSum == targetSum)
                {
                    return true;
                }

                return bactracking(currSum + nums[i], i + 1) || bactracking(currSum, i + 1);
            }

            return bactracking(0, 0);
        }

        // TODO: implement the memoisation
        public bool CanPartition_backtracking_recursion_memoised(int[] nums)
        {
            // sort can reduce the TLE
            var numsList = nums.ToList();
            numsList.Sort((x, y) => y.CompareTo(x));
            nums = numsList.ToArray();

            IEnumerable<int> enemerableNums = nums;
            var totalSum = enemerableNums.Aggregate(
                0,
                (acc, cur) =>
                {
                    return acc + cur;
                }
            );

            if (totalSum % 2 != 0)
                return false;

            var targetSum = totalSum / 2;

            bool bactracking(int remaining, int i)
            {
                if (i >= nums.Length || remaining < nums[i])
                {
                    return false;
                }

                if (remaining == nums[i])
                {
                    return true;
                }

                return bactracking(remaining - nums[i], i + 1) || bactracking(remaining, i + 1);
            }

            return bactracking(targetSum, 0);
        }

        // knapsack approach
    }
}

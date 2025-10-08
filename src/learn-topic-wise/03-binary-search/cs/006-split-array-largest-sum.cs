// https://leetcode.com/problems/split-array-largest-sum
namespace learning_dsa_csharp._05_binary_Search._006_split_array_largest_sum
{
    // Solution - https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/solutions/769703/python-clear-explanation-powerful-ultimate-binary-search-template-solved-many-problems
    internal class OthersSoln
    {
        public int SplitArray(int[] nums, int k)
        {
            bool feasible(int threshold)
            {
                int count = 1;
                int total = 0;

                foreach (var w in nums)
                {
                    total += w;
                    if (total > threshold)
                    {
                        total = w;
                        count += 1;

                        if (count > k)
                            return false;
                    }
                }

                return true;
            }

            int BinarySearchTemplate(int[] array, int l, int r)
            {
                while (l < r)
                {
                    int mid = (l + r) / 2;
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
            for (int i = 0; i < nums.Length; ++i)
            {
                max = Math.Max(max, nums[i]);
                sum += nums[i];
            }

            return BinarySearchTemplate(nums, max, sum);
        }
    }
}

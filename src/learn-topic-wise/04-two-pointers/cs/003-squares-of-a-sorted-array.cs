namespace learning_dsa_csharp._02_two_pointers._003_squares_of_a_sorted_array
{
    internal class MySoln
    {
        int[] insertItem(int[] nums, int t)
        {
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                if (t < nums[i])
                {
                    (nums[i], t) = (t, nums[i]);
                }
            }

            return nums;
        }

        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            List<int> negList = new();

            int i = 0;
            while (i < n && nums[i] < 0)
            {
                negList.Add(Math.Abs(nums[i]));
                i++;
            }

            if (i == n)
            {
                Array.Reverse(nums);
            }
            else
            {
                int j = 0;
                while (i < n)
                {
                    nums[j] = nums[i];
                    ++i;
                    ++j;
                }

                while (j < n)
                {
                    nums[j] = int.MaxValue;
                    ++j;
                }

                while (negList.Count > 0)
                {
                    int cur = negList[0];
                    negList.RemoveAt(0);

                    nums = insertItem(nums, cur);
                }
            }

            for (i = 0; i < n; ++i)
            {
                nums[i] *= nums[i];
            }

            return nums;
        }
    }

    internal class OthersSoln
    {
        public int[] SortedSquares(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            int index = nums.Length - 1;
            int[] result = new int[nums.Length];
            while (left <= right)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    result[index] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[index] = nums[right] * nums[right];
                    right--;
                }
                index--;
            }
            return result;
        }
    }
}

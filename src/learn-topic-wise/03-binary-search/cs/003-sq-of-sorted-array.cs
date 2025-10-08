// https://leetcode.com/problems/squares-of-a-sorted-array
namespace learning_dsa_csharp._05_binary_Search._003_sq_of_sorted_array
{
    internal class MySOln
    {
        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            List<int> negN = new();
            List<int> sqList = new();

            int i = 0;
            while (nums[i] < 0 && i < n)
            {
                negN.Add(nums[i] * -1);
                ++i;
            }

            // if all are -ve
            if (i == n)
            {
                Array.Reverse(nums);
            }
            else
            {
                for (int j = 0; i < n; ++j)
                {
                    nums[j] = nums[i];
                    ++i;
                }

                while (negN.Count > 0)
                {
                    int nL = negN.Count;
                    int cur = negN[0];
                    negN.RemoveAt(0);

                    int l = 0;
                    int r = n - nL - 1;
                    while (l < r)
                    {
                        int m = (l + r) / 2;
                        if (nums[m] == cur)
                        {
                            l = m;
                            break;
                        }
                        if (cur > nums[m])
                        {
                            l = m + 1;
                        }
                        else
                        {
                            r = m - 1;
                        }
                    }
                }
            }

            for (i = 0; i < n; ++i)
            {
                nums[i] *= nums[i];
            }

            return nums;
        }
    }
}

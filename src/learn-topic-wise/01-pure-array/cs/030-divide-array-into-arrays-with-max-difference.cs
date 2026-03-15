namespace learning_dsa_csharp._01_strings_arrays_hash._030_divide_array_into_arrays_with_max_difference;

internal class OthersFastestSoln
{
    public int[][] DivideArray(int[] nums, int k)
    {
        Array.Sort(nums);

        int[][] res = new int[nums.Length / 3][];
        int Index = 0;
        for (int i = 0; i < nums.Length; i += 3)
        {
            if (nums[i + 2] - nums[i] <= k)
            {
                res[Index] = [nums[i], nums[i + 1], nums[i + 2]];
                Index++;
            }
            else
                return [];
        }
        return res;
    }
}

// ranked the slowest, but List<int> sort is much slower
public class MySoln
{
    public int[][] DivideArray(int[] nums, int k)
    {
        int n = nums.Length;

        Array.Sort(nums);

        int m = n / 3;
        int[][] res = new int[m][];

        int i = 0;
        while (i < m)
        {
            int n1 = nums[3 * i];
            int n2 = nums[3 * i + 1];
            int n3 = nums[3 * i + 2];

            if (n3 - n1 > k)
            {
                return [];
            }

            res[i] = [n1, n2, n3];
            ++i;
        }

        return res;
    }
}

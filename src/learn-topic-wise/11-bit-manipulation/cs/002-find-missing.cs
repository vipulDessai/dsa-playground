// https://leetcode.com/problems/missing-number/
namespace learning_dsa_csharp._17_bit_manipulation._002_find_missing
{
    internal class Soln
    {
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int bits = 0;

            for (int i = 1; i <= n; ++i)
                bits ^= i;

            for (int i = 0; i < n; ++i)
                bits ^= nums[i];

            return bits;
        }
    }
}

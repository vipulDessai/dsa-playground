// https://leetcode.com/problems/minimum-number-of-operations-to-make-array-xor-equal-to-k
namespace learning_dsa_csharp._17_bit_manipulation._006_minimum_number_of_operations_to_make_array_xor_equal_to_k
{
    // https://leetcode.com/problems/minimum-number-of-operations-to-make-array-xor-equal-to-k/solutions/4518337/xor-is-odd-1-s-detector-explained-with-example-xor-rule
    internal class OthersSoln
    {
        public int MinOperations(int[] nums, int k)
        {
            int[] oneCount = new int[32];
            foreach (int num in nums)
            {
                for (int i = 0; i < 32; i++)
                {
                    if ((num & (1 << i)) > 0)
                        oneCount[i]++;
                }
            }

            int ans = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((k & (1 << i)) > 0) // if ith bit in k = 1 (set)
                {
                    if (oneCount[i] % 2 == 0) // we wanted odd number of 1's but got even number of 1's
                        ans++;
                }
                else // if ith bit in k = 0 (unset)
                {
                    if (oneCount[i] % 2 != 0) // we wanted even number of 1's but got odd number of 1's
                        ans++;
                }
            }

            return ans;
        }
    }
}

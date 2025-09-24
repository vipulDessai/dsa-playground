namespace learning_dsa_csharp._17_bit_manipulation._009_single_number_3
{
    // https://leetcode.com/problems/single-number-iii/solutions/5233206/demon-level-explanation-3-approaches
    internal class OthersSoln
    {
        public int[] SingleNumber(int[] nums)
        {
            int xor2no = 0;
            foreach (int num in nums)
            {
                xor2no ^= num;
            }

            int lowestBit = xor2no & (-xor2no);

            int[] result = new int[2];
            foreach (int num in nums)
            {
                if ((lowestBit & num) == 0)
                {
                    result[0] ^= num;
                }
                else
                {
                    result[1] ^= num;
                }
            }

            return result;
        }
    }
}

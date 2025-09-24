namespace learning_dsa_csharp._17_bit_manipulation._004_find_the_duplicate_number
{
    // https://leetcode.com/problems/find-the-duplicate-number/solutions/72872/o-32-n-solution-using-bit-manipulation-in-10-lines
    internal class MySoln
    {
        public int FindDuplicate(int[] nums)
        {
            int n = nums.Length;

            int res = 0;
            for (int i = 0; i < 32; ++i)
            {
                int bit = 1 << i,
                    a = 0,
                    b = 0;
                for (int j = 0; j < n; ++j)
                {
                    if (j > 0 && (bit & j) > 0)
                        ++a;
                    if ((bit & nums[j]) > 0)
                        ++b;
                }

                if (b > a)
                    res |= bit;
            }

            return res;
        }
    }
}

namespace learning_dsa_csharp._17_bit_manipulation._001_dec_to_bin
{
    internal class MySoln
    {
        public int[] DecToBin(int num)
        {
            int[] res = new int[32];
            for (int i = 31; i >= 0; --i)
            {
                int mask = 1 << i;
                res[31 - i] = (mask & num) == 0 ? 0 : 1;
            }

            return res;
        }
    }
}

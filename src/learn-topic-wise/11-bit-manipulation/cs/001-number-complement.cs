namespace learning_dsa_csharp._17_bit_manipulation._001_number_complement
{
    internal class MySoln
    {
        public int FindComplement(int num)
        {
            int[] DecToBin(int num)
            {
                int[] res = new int[32];
                for (int i = 31; i >= 0; --i)
                {
                    int mask = 1 << i;
                    res[31 - i] = (mask & num) == 0 ? 0 : 1;
                }

                return res;
            }

            int[] b = DecToBin(num);
            bool flag = false;
            int res = 0;
            for (int i = 0; i < b.Length; ++i)
            {
                if (b[i] == 1)
                {
                    flag = true;
                }

                if (flag)
                {
                    res += b[i] == 0 ? (int)Math.Pow(2, (31 - i)) : 0;
                }
            }

            return res;
        }
    }
}

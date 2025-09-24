namespace learning_dsa_csharp._17_bit_manipulation._003_bitwise_and_of_numbers_range;

internal class MySoln
{
    private int[] DecToBinary(int num)
    {
        int[] b = new int[32];
        for (int i = 31; i >= 0; --i)
        {
            int mask = 1 << i;
            b[31 - i] = (num & mask) != 0 ? 1 : 0;
        }

        //int i = 0;
        //while (num > 0)
        //{
        //    b[i] = num % 2;
        //    num /= 2;
        //    i++;
        //}

        return b;
    }

    private int BinToDec(int[] bR)
    {
        int n = bR.Length;

        double num = 0;
        for (int i = 0; i < n; i++)
        {
            num += bR[i] * Math.Pow(2, i);
        }

        return (int)num;
    }

    public int RangeBitwiseAnd(int left, int right)
    {
        int[] l = DecToBinary(left);
        int[] r = DecToBinary(right);

        int[] res = new int[32];
        bool f = true;
        for (int i = 0; i < 32; i++)
        {
            int j = 31 - i;
            if (f && l[j] == r[j])
            {
                res[j] = l[j];
            }
            else
            {
                f = false;
                res[j] = 0;
            }
        }

        return BinToDec(res);
    }
}

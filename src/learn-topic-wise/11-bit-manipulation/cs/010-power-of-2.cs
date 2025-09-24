// https://leetcode.com/problems/power-of-two/
namespace learning_dsa_csharp._17_bit_manipulation._001_power_of_2;

internal class MySoln_Recursion
{
    public bool IsPowerOfTwo(int n)
    {
        if (n == 0)
        {
            return false;
        }
        else if (n == 1)
        {
            return true;
        }
        else
        {
            if (n % 2 == 0)
            {
                n /= 2;
                return IsPowerOfTwo(n);
            }
            else
            {
                return false;
            }
        }
    }
}

internal class Others_Soln_Bit_manipulation
{
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }
}

internal class Others_Soln_Power
{
    public bool IsPowerOfTwo(int n)
    {
        int i = 0;
        double res;
        do
        {
            res = Math.Pow(2, i);
            i++;
        } while (res < n);

        return res == n;
    }
}

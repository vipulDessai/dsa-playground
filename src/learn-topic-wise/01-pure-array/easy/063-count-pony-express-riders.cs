// https://www.codewars.com/kata/5b18e9e06aefb52e1d0001e9/train/javascript
namespace learning_dsa_csharp._01_strings_arrays_hash._063_count_pony_express_riders
{
    internal class MySoln
    {
        public static int Riders(int[] stations)
        {
            int n = stations.Length;

            int sum = 0;
            int res = 0;
            for (int i = 0; i < n; ++i)
            {
                if (sum + stations[i] > 100)
                {
                    sum = 0;
                    ++res;
                }

                sum += stations[i];
            }

            return res + 1;
        }
    }
}

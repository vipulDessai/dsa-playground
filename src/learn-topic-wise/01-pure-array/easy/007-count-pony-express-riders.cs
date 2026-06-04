// https://www.codewars.com/kata/5b18e9e06aefb52e1d0001e9/train/javascript
namespace learning_dsa_csharp._01_strings_arrays_hash._063_count_pony_express_riders
{
    internal class Solution
    {
        public static int riders(int[] stations)
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

    class Execute
    {
        public static void Main(string[] args)
        {
            int[] input = [1, 3, 4, 2, 2];
            var output = Solution.riders(input);

            Console.WriteLine(output);
        }
    }
}

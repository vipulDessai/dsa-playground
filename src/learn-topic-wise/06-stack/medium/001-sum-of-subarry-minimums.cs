// https://leetcode.com/problems/sum-of-subarray-minimums/description/
namespace learning_dsa_csharp._04_stack._002_sum_of_subarry_minimums
{
    interface Solution
    {
        public int SumSubarrayMins(int[] arr);
    }

    internal class MySolnBruteForce : Solution
    {
        // TLE 79/87
        public int SumSubarrayMins(int[] arr)
        {
            long MOD = 1000000007;

            int n = arr.Length;

            long sum = 0;
            for (int i = 0; i < n; ++i)
            {
                int min = int.MaxValue;
                for (int j = i; j < n; ++j)
                {
                    min = Math.Min(min, arr[j]);

                    sum = (long)min + sum % MOD;
                }
            }

            return (int)sum;
        }
    }

    // using monotonic stack approach
    internal class StackSolutionO_N : Solution
    {
        public int SumSubarrayMins(int[] arr)
        {
            int n = arr.Length;

            Stack<int> s = new Stack<int>();
            int[] l = new int[n];
            int[] r = new int[n];
            Array.Fill(l, -1);  // smallest element to the left
            Array.Fill(r, n);   // smallest element to the right

            for (int i = 0; i < n; ++i)
            {
                while (s.Count > 0 &&  arr[i] <= arr[s.Peek()])
                {
                    s.Pop();
                }

                if (s.Count > 0)
                {
                    l[i] = s.Peek();
                }

                s.Push(i);
            }

            s.Clear();
            for (int i = n - 1; i >= 0; --i)
            {
                while (s.Count > 0 && arr[i] < arr[s.Peek()])
                {
                    s.Pop();
                }

                if (s.Count > 0)
                {
                    r[i] = s.Peek();
                }

                s.Push(i);
            }

            long MOD = 1000000007;
            long sum = 0;
            for (int i = 0; i < n; ++i)
            {
                // formula 
                // since sum is of type long, better to have all variables in
                // the formula as long
                // (i - l[i]) * (r[i] - i) gives the number of subarrays where the
                // arr[i] is the minimum
                // so once we have the count ssimply multiplying the arr[i] gives the sum
                // as the ask is to sum the minimum of all subarrays
                sum += ((i - l[i]) * (r[i] - i) * (long)arr[i]) % MOD;
                sum %= MOD;
            }
            return (int)sum;
        }
    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new StackSolutionO_N();

            var input = new int[] { 3, 1, 2, 4 };
            input = new int[] { 3, 3 };
            Console.WriteLine(s.SumSubarrayMins(input));
        }
    }
}

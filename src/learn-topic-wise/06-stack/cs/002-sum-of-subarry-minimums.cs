// https://leetcode.com/problems/longest-consecutive-sequence/description/
namespace learning_dsa_csharp._04_stack._002_sum_of_subarry_minimums
{
    internal class MySolnBruteForce
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
    internal class StackSolutionO_N
    {
        public int SumSubarrayMins(int[] arr)
        {
            int n = arr.Length;

            Stack<int> s = new Stack<int>();
            int[] l = new int[n];
            int[] r = new int[n];
            Array.Fill(l, -1);
            Array.Fill(r, n);

            for (int i = 0; i < n; ++i)
            {
                while (s.Count > 0 && arr[s.Peek()] >= arr[i])
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
                while (s.Count > 0 && arr[s.Peek()] > arr[i])
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
                // since sum is of type long, better to have all variables in
                // the formula as long
                sum += ((i - l[i]) * (r[i] - i) % MOD * (long)arr[i]) % MOD;
                sum %= MOD;
            }
            return (int)sum;
        }
    }
}

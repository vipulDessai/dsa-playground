// [Next Greater Element I](https://leetcode.com/problems/next-greater-element-i/)

namespace learning_dsa_csharp._04_stack._001_monotonic_stack_next_greater_element
{
    interface IMonotonicStackApproach
    {
        public (int[], int[]) NextGraeterElem(int[] heights);
    }
    internal class Solution : IMonotonicStackApproach
    {
        public (int[], int[]) NextGraeterElem(int[] heights)
        {
            int n = heights.Length;

            int[] r = new int[n];
            Stack<int> s = new Stack<int>();

            // from right to left
            for (int i = n - 1; i >= 0; --i)
            {
                while (s.Count > 0 && heights[s.Peek()] < heights[i])
                {
                    s.Pop();
                }

                if (s.Count == 0)
                {
                    r[i] = -1;
                }
                else
                {
                    r[i] = s.Peek();
                }

                s.Push(i);
            }

            s.Clear();
            int[] l = new int[n];

            // from left to right
            for (int i = 0; i < n; ++i)
            {
                while (s.Count > 0 && heights[s.Peek()] < heights[i])
                {
                    s.Pop();
                }

                if (s.Count == 0)
                {
                    l[i] = -1;
                }
                else
                {
                    l[i] = s.Peek();
                }

                s.Push(i);
            }

            return (r, l);
        }
    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            IMonotonicStackApproach s = new Solution();

            var input = new int[] { 3, 4, 5, 1, 2 };

            var (out1, out2) = s.NextGraeterElem(input);

            Console.WriteLine("Out 1: " + string.Join(", ", out1));
            Console.WriteLine("Out 2: " + string.Join(", ", out2));
        }
    }
}
// [Largest Rectangle in Histogram](https://leetcode.com/problems/largest-rectangle-in-histogram/description/)

namespace learning_dsa_csharp._04_stack._001_monotonic_stack_next_greater_element
{
    internal class Solution
    {
        public int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            Stack<int> stack = new Stack<int>();

            // Nearest smaller to left
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                left[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            stack.Clear();

            // Nearest smaller to right
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                right[i] = stack.Count == 0 ? n : stack.Peek();
                stack.Push(i);
            }

            // Compute max area
            int maxArea = 0;
            for (int i = 0; i < n; i++)
            {
                int width = right[i] - left[i] - 1;
                int area = heights[i] * width;
                maxArea = Math.Max(maxArea, area);
            }

            return maxArea;
        }

    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();

            var input = new int[] { 2, 1, 5, 6, 2, 3 };
            Console.WriteLine(s.LargestRectangleArea(input));
        }
    }
}
// [Next Greater Element I](https://leetcode.com/problems/next-greater-element-i/)

namespace learning_dsa_csharp._04_stack._001_monotonic_stack_next_greater_element
{
    public class Solution
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int n = nums2.Length;
            Stack<int> st = new Stack<int>();
            Dictionary<int, int> dp = new();
            for (int i = n - 1; i >= 0; --i)
            {
                var cur = nums2[i];
                while (st.Count > 0 && nums2[st.Peek()] < cur)
                    st.Pop();

                if (st.Count == 0)
                    dp[cur] = -1;
                else
                {
                    dp[cur] = nums2[st.Peek()];
                }

                st.Push(i);
            }

            int m = nums1.Length;
            int[] res = new int[m];
            for (int i = 0; i < m; ++i)
            {
                res[i] = dp[nums1[i]];
            }

            return res;
        }
    }

    internal class Execute
    {
        public static void Main(string[] args)
        {
            Solution s = new Solution();

            var input1 = new int[] { 4, 1, 2 };
            var input2 = new int[] { 1, 3, 4, 2 };

            Console.WriteLine(string.Join(", ", s.NextGreaterElement(input1, input2)));
        }
    }
}
namespace learning_dsa_csharp._04_stack._001_monotonic_stack_next_greater_element
{
    internal class MonotonicStackApproach
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

    // https://leetcode.com/problems/next-greater-element-i/
    public class MySolnNextGreaterElement
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
}

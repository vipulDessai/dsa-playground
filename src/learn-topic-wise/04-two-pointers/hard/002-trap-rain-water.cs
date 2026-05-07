// https://leetcode.com/problems/trapping-rain-water/
namespace learning_dsa_csharp._02_two_pointers._002_trap_rain_water
{
    internal class OtherSoln_divide_and_conquer
    {
        // solution - https://leetcode.com/problems/trapping-rain-water/solutions/409175/java-detailed-explanations-illustrations-divide-and-conquer-dp-two-pointers/?envType=list&envId=ph3blvae
        public int Trap(int[] height)
        {
            int n = height.Length;
            if (n <= 2)
                return 0;
            // pre-compute
            int[] leftMax = new int[n];
            int[] rightMax = new int[n];
            // init
            leftMax[0] = height[0];
            rightMax[n - 1] = height[n - 1];
            for (int i = 1, j = n - 2; i < n; ++i, --j)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], height[i]);
                rightMax[j] = Math.Max(rightMax[j + 1], height[j]);
            }
            // count water
            int totalWater = 0;
            // do not consider the first and the last places
            for (int k = 1; k < n - 1; ++k)
            {
                int water = Math.Min(leftMax[k - 1], rightMax[k + 1]) - height[k];
                totalWater += (water > 0) ? water : 0;
            }
            return totalWater;
        }
    }

    // solution - https://leetcode.com/problems/trapping-rain-water/solutions/5010020/monotonic-stack-vs-priority-queue-using-pyplot-explain-3ms-beats-99-10/
    public class OtherSoln_Monotonic_stack
    {
        public int Trap(int[] height)
        {
            int n = height.Length;
            int res = 0;
            Stack<int> st = new Stack<int>();

            for (int i = 0; i < n; ++i)
            {
                while (st.Count > 0 && height[st.Peek()] < height[i])
                {
                    int m = st.Peek();

                    st.Pop();
                    if (st.Count == 0)
                        break;

                    int l = st.Peek();
                    int h = Math.Min(height[i] - height[m], height[l] - height[m]);
                    int w = i - l - 1;

                    res += h * w;
                }

                st.Push(i);
            }

            return res;
        }
    }
}

// https://leetcode.com/problems/maximize-happiness-of-selected-children
namespace learning_dsa_csharp._01_strings_arrays_hash._054_maximize_happiness_of_selected_children
{
    // https://leetcode.com/problems/maximize-happiness-of-selected-children/solutions/5132855/beats-97-44-of-users-with-java-fastest-2-approaches-easy-well-explained-solution
    internal class OthersSoln
    {
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            Array.Sort(happiness);
            int dec = 0,
                n = happiness.Length;
            long ans = 0;

            for (int i = n - 1; i >= n - k; i--)
            {
                ans += Math.Max(0, happiness[i] - dec);
                dec++;
            }

            return ans;
        }
    }
}

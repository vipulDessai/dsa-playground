// https://leetcode.com/contest/biweekly-contest-127/problems/shortest-subarray-with-or-at-least-k-ii/
namespace learning_dsa_csharp._17_bit_manipulation._005_Shortest_subarray_with_or_at_least_k_ii
{
    internal class MySoln
    {
        // TODO - doesnt work
        public int MinimumSubarrayLength(int[] nums, int k)
        {
            int n = nums.Length;

            int l = 0,
                r = 0,
                res = int.MaxValue;
            int b = 0;
            while (r < n)
            {
                b |= nums[r];

                while (b > k)
                {
                    res = Math.Min(res, (r - l) + 1);

                    int i = l + 1;
                    b = 0;
                    while (i <= r)
                    {
                        b |= nums[i];
                        ++i;
                    }

                    ++l;
                }

                ++r;
            }

            return res == int.MaxValue ? -1 : res;
        }
    }

    // https://leetcode.com/problems/shortest-subarray-with-or-at-least-k-ii/solutions/4948082/c-java-python-2-approaches-sliding-window-binary-search-two-pointers
    class OthersSoln
    {
        private void update(int[] bits, int x, int change)
        {
            // insert or remove element from window, time: O(32)
            for (int i = 0; i < 32; i++)
            {
                if (((x >> i) & 1) != 0)
                {
                    bits[i] += change;
                }
            }
        }

        private int bitsToNum(int[] bits)
        {
            // convert 32-size bits array to integer, time: O(32)
            int result = 0;
            for (int i = 0; i < 32; i++)
            {
                if (bits[i] != 0)
                {
                    result |= 1 << i;
                }
            }
            return result;
        }

        public int MinimumSubarrayLength(int[] nums, int k)
        {
            int n = nums.Length,
                result = n + 1;
            int[] bits = new int[32];
            for (int start = 0, end = 0; end < n; end++)
            {
                update(bits, nums[end], 1); // insert nums[end] into window
                while (start <= end && bitsToNum(bits) >= k)
                {
                    result = Math.Min(result, end - start + 1);
                    update(bits, nums[start], -1); // remove nums[start] from window

                    ++start;
                }
            }
            return result != n + 1 ? result : -1;
        }
    }
}

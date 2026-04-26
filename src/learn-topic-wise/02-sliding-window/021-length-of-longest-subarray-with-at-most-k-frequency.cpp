// [Length of Longest Subarray With at Most K Frequency](https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency/description/)

#include <iostream>

namespace _021_length_of_longest_subarray_with_at_most_k_frequency {
    class Solution {
    public:
        int maxSubarrayLength(vector<int>& nums, int k) {
            // int n = nums.Length;
            // Dictionary<int, int> m = new();
            // int l = 0,
            //     r = 0;
            // int c = int.MinValue;
            // while (r < n)
            // {
            //     int cur = nums[r];

            //     if (!m.ContainsKey(cur))
            //     {
            //         m[cur] = 0;
            //     }

            //     if (m[cur] < k)
            //     {
            //         m[cur]++;
            //         r++;

            //         c = Math.Max(c, r - l);
            //     }
            //     else
            //     {
            //         int lN = nums[l];
            //         m[lN]--;
            //         if (m[lN] == 0)
            //         {
            //             m.Remove(lN);
            //         }
            //         l++;
            //     }
            // }

            // return c;
        }
    };
};

class Execute {
public:
    static void Main() {
        // Instantiate classA from _021_foo_bar
        _021_length_of_longest_subarray_with_at_most_k_frequency::Solution obj;
        obj.maxSubarrayLength();
    }
};

int main() {
    Execute::Main();
    return 0;
}
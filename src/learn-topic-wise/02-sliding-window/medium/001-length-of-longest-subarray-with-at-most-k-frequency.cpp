// [Length of Longest Subarray With at Most K Frequency](https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency/description/)

#include <iostream>
#include <vector>
#include <limits>
#include <unordered_map>
#include <algorithm>

using namespace std;

namespace _021_length_of_longest_subarray_with_at_most_k_frequency
{
    class Solution
    {
    public:
        int maxSubarrayLength(vector<int> &nums, int k)
        {
            unordered_map<int, int> freq;
            int l = 0,
                r = 0;
            int res = numeric_limits<int>::min();
            
            while (r < nums.size())
            {
                int cur = nums[r];
                ++freq[cur];

                while(freq[cur] > k)
                {
                    --freq[nums[l]];
                    ++l;
                }

                ++r;
            }

            return res;
        }
    };
};

class Execute
{
public:
    static void Main()
    {
        _021_length_of_longest_subarray_with_at_most_k_frequency::Solution obj;

        vector<int> input = {};
        int k = 0;

        cout << obj.maxSubarrayLength(input, k);
    }
};

int main()
{
    Execute::Main();
    return 0;
}
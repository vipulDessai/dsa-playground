// [binary subarrays with sum](https://leetcode.com/problems/binary-subarrays-with-sum/)

#include <iostream>
#include <vector>

using namespace std;

namespace _004_binary_subarray_with_sum
{
    class Solution
    {
    private:
        int atMost(vector<int> &nums, int s)
        {
            if (s < 0)
                return 0;

            int l = 0, r = 0, sum = 0, res = 0;
            while (r < nums.size())
            {
                sum += nums[r];
                while (sum > s)
                {
                    sum -= nums[l++];
                }

                res += (r - l + 1);

                ++r;
            }
            return res;
        }

    public:
        int numSubarraysWithSum(vector<int> &nums, int goal)
        {
            // formula 
            // when target is exactly == answer needed, i.e. not less or more
            return atMost(nums, goal) - atMost(nums, goal - 1);
        }
    };
}

class Execute
{
public:
    static void Main()
    {
        _004_binary_subarray_with_sum::Solution obj;
        vector<int> input = {1, 0, 1, 0, 1};
        int g = 2;

        cout << obj.numSubarraysWithSum(input, g);
    }
};

int main()
{
    Execute::Main();
    return 0;
}
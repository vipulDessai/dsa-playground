// [Subarrays with K Different Integers](https://leetcode.com/problems/subarrays-with-k-different-integers)

#include <iostream>
#include <vector>
#include <unordered_map>

using namespace std;

namespace _004_subarrays_with_k_different_integers
{
    class Solution
    {
    public:
        int subarraysWithKDistinct(vector<int> &nums, int k)
        {
            // formula
            // when target is exactly == answer needed, i.e. not less or more
            return helper(nums, k) - helper(nums, k - 1);
        }

    private:
        int helper(vector<int> &nums, int k)
        {

            unordered_map<int, int> freq;

            int l = 0,
                r = 0,
                res = 0;
            while (r < nums.size())
            {
                ++freq[nums[r]];

                while (freq.size() > k)
                {
                    int curL = nums[l];
                    --freq[curL];

                    if (freq[curL] == 0)
                    {
                        freq.erase(curL);
                    }

                    ++l;
                }

                res += r - l + 1;

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
        _004_subarrays_with_k_different_integers::Solution s;

        vector<int> input = {1, 2, 1, 2, 3};
        int k = 2;
        cout << s.subarraysWithKDistinct(input, k);
    };
};

int main()
{
    Execute::Main();
    return 0;
}
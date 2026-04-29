// [Count Subarrays Where Max Element Appears at Least K Times](https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times)

#include <iostream>
#include <vector>

using namespace std;

namespace _003_count_suarrays_where_max_element_appears_at_least_k_times
{
    class Solution
    {
    public:
        long long countSubarrays(vector<int> &nums, int k)
        {
            int n = nums.size();

            int m = *max_element(nums.begin(), nums.end());

            long long res = 0;
            int l = 0, r = 0, c = 0;

            m = 3;
            while (r < n) {
                if(nums[r] == m) {
                    ++c;
                }

                while (c >= k)
                {
                    if(nums[l] == m)
                        --c;

                    ++l;
                }

                // formula
                res += l;
                
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
        _003_count_suarrays_where_max_element_appears_at_least_k_times::Solution obj;

        vector<int> input = {1, 3, 2, 3, 3};
        int k = 2;

        cout << obj.countSubarrays(input, k);
    }
};

int main()
{
    Execute::Main();
    return 0;
}
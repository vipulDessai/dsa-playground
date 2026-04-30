// [Count Number of Nice Subarrays](https://leetcode.com/problems/count-number-of-nice-subarrays/)

#include <iostream>
#include <vector>

using namespace std;

namespace _004_count_number_of_nice_subarrays
{
    class Solution
    {
    private:
        int atMost(vector<int> &nums, int K)
        {
            int n = nums.size();
            int left = 0, countOdd = 0;
            int res = 0;

            for (int right = 0; right < n; right++)
            {
                if (nums[right] % 2 == 1)
                    countOdd++;

                while (countOdd > K)
                {
                    if (nums[left] % 2 == 1)
                        countOdd--;
                    left++;
                }

                res += (right - left + 1);
            }
            return res;
        }

    public:
        int numberOfSubarrays(vector<int> &nums, int k)
        {
            // formula
            return atMost(nums, k) - atMost(nums, k - 1);
        }
    };
};

class Execute
{
public:
    static void Main()
    {
        _004_count_number_of_nice_subarrays::Solution obj;

        vector<int> input = {1, 3, 2, 3, 3};
        int k = 2;

        cout << obj.numberOfSubarrays(input, k);
    }
};

int main()
{
    Execute::Main();
    return 0;
}
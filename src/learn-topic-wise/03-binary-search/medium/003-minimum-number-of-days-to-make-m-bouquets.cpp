// [Minimum Number of Days to Make m Bouquets](https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets)

#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

namespace _003_minimum_number_of_days_to_make_m_bouquets
{
    class Solution
    {
    private:
        bool isFeasible(vector<int> &bloomDay, int d, int m, int k)
        {
            int n = bloomDay.size();
            int curM = 0, curK = 1, i = 0;

            while (curM < m && i < n)
            {
                if (bloomDay[i] <= d)
                {
                    if (curK == k)
                    {
                        ++curM;
                        curK = 0;
                    }

                    ++curK;
                }
                else
                {
                    curK = 1;
                }

                ++i;
            }

            if (curM == m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    public:
        int minDays(vector<int> &bloomDay, int m, int k)
        {
            int r = *max_element(bloomDay.begin(), bloomDay.end());
            int l = *min_element(bloomDay.begin(), bloomDay.end());

            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (isFeasible(bloomDay, mid, m, k))
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return l < r ? l : -1;
        }
    };
}

class Execute
{
public:
    static void Main()
    {
        _003_minimum_number_of_days_to_make_m_bouquets::Solution obj;
        vector<int> input;
        int m, k;

        input = {1, 10, 3, 10, 2};
        m = 3;
        k = 1;

        input = {7, 7, 7, 7, 12, 7, 7};
        m = 2;
        k = 3;

        cout << obj.minDays(input, m, k);
    };
};

int main()
{
    Execute::Main();
    return 0;
}
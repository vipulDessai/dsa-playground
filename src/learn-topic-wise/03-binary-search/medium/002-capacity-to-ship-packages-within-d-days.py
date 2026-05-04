# [Capacity To Ship Packages Within D Days](https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/description/)

import math

class Solution(object):
    def feasible(self, weights, c, days):
        """
        :type weights: List[int]
        :type c: int
        :type days: int
        :rtype: bool
        """
        curDays, total = 1, 0

        for w in weights:
            total += w
            if (total > c): # too heavy, wait for the next day
                total = w
                curDays += 1

                if (curDays > days): # cannot ship within D days
                    return False

        return True

    def shipWithinDays(self, weights, days):
        """
        :type weights: List[int]
        :type days: int
        :rtype: int
        """
        l, r = max(weights), sum(weights)
        while (l < r):
            m = l + (r - l) // 2  # // for floor  
            if (self.feasible(weights, m, days)):
                r = m
            else:
                l = m + 1

        return l

def Main():
    input = [1,2,3,4,5,6,7,8,9,10]
    days = 5

    input = [1,2,3,4,5]
    days = 3

    sol = Solution()
    print(sol.shipWithinDays(input, days))

if __name__ == "__main__":
    Main()
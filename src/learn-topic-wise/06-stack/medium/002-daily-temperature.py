# [Daily Temperatures](https://leetcode.com/problems/daily-temperatures/description/)

from typing import List


class Solution:
    def dailyTemperatures(self, temperatures: List[int]) -> List[int]:
        n = len(temperatures)
        ans = [None] * n

        s = []

        for i in range(n - 1, -1, -1):
            while len(s) > 0 and temperatures[i] >= temperatures[s[len(s) - 1]]:
                s.pop()

            if len(s) == 0:
                ans[i] = 0
            else:
                ans[i] = s[len(s) - 1] - i

            s.append(i)

        return ans


def Main():
    input = [73, 74, 75, 71, 69, 72, 76, 73]
    sol = Solution()
    output = sol.dailyTemperatures(input)

    for item in output:
        print(item)


if __name__ == "__main__":
    Main()

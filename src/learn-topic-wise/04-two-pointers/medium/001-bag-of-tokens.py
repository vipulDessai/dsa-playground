# [Bag of Tokens](https://leetcode.com/problems/bag-of-tokens/)

from typing import List


class Solution:
    def bagOfTokensScore(self, tokens: List[int], power: int) -> int:
        tokens.sort()

        l, r = 0, len(tokens) - 1
        s = max_score = 0

        while l <= r:
            if power >= tokens[l]:
                power -= tokens[l]
                s += 1
                max_score = max(max_score, s)

                l += 1
            elif s > 0:
                s -= 1
                power += tokens[r]

                r -= 1
            else:
                break

        return max_score


def Main():
    input = [100]
    p = 50

    input = [200, 100]
    p = 150

    s = Solution()
    out = s.bagOfTokensScore(input, p)

    print(out)


if __name__ == "__main__":
    Main()

# [Path with Maximum Gold](https://leetcode.com/problems/path-with-maximum-gold/)

from typing import List


class Solution:
    def dfs(self, grid: List[List[int]], r: int, c: int):
        m = len(grid)
        n = len(grid[0])

        directions = [[-1, 0], [0, 1], [1, 0], [0, -1]]

        t = grid[r][c]
        grid[r][c] = -1

        _m = 0
        for i in range(4):
            dR, dC = directions[i]
            nR = r + dR
            nC = c + dC

            if nR < 0 or nR >= m or nC < 0 or nC >= n:
                continue

            if grid[nR][nC] == -1 or grid[nR][nC] == 0:
                continue

            _m = max(_m, self.dfs(grid, nR, nC))

        grid[r][c] = t
        return grid[r][c] + _m

    def getMaximumGold(self, grid: List[List[int]]) -> int:
        m = len(grid)
        n = len(grid[0])

        _m = 0
        for i in range(m):
            for j in range(n):
                _m = max(_m, self.dfs(grid, i, j))

        return _m


def Main():
    grid = [[0, 6, 0], [5, 8, 7], [0, 9, 0]]

    s = Solution()
    out = s.getMaximumGold(grid=grid)

    print(out)


if __name__ == "__main__":
    Main()

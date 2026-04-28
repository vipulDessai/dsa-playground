# [Largest Local Values in a Matrix](https://leetcode.com/problems/largest-local-values-in-a-matrix/)

class Solution(object):
    def getMax(self, grid, r, c):
        """
        :type grid: List[List[int]]
        :type r: int
        :type c: int
        """
        _max = -2 ** 31
        for i in range (r, r + 3):
            for j in range(c, c + 3):
                _max = max(_max, grid[i][j])
        
        return _max

    def largestLocal(self, grid):
        """
        :type grid: List[List[int]]
        :rtype: List[List[int]]
        """

        n = len(grid)
        res = [[0 for _ in range(n - 2)] for _ in range (n - 2)]

        for i in range(0, n - 2):
            for j in range(0, n - 2):
                res[i][j] = self.getMax(grid, i, j)

        return res
    
def Main():
    grid = [
        [9, 9, 8, 1],
        [5, 6, 2, 6],
        [8, 2, 6, 4],
        [6, 2, 2, 2]
    ]
    
    sol = Solution()
    output = sol.largestLocal(grid)

    for row in output:
        print(row)


if __name__ == "__main__":
    Main()
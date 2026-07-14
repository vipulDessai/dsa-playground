# https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree

from typing import List, Optional
from utils.generate_trees import Utils, TreeNode


class Solution:
    def checkPal(self, c: List[int], pLen: int):
        if pLen % 2 == 0:
            for i in range(9):
                if c[i] % 2 != 0:
                    return 0
        else:
            oddCount = 0
            for i in range(9):
                if c[i] % 2 == 1:
                    oddCount += 1

                if oddCount == 2:
                    return 0

        return 1

    def dfs(self, n: TreeNode, cur: List[int], pLen: int):
        if n == None:
            return 0

        if n.left == None and n.right == None:
            cur[n.val - 1] += 1
            res = self.checkPal(cur, pLen + 1)
            cur[n.val - 1] -= 1
            return res

        cur[n.val - 1] += 1

        r = self.dfs(n.left, cur, pLen + 1) + self.dfs(n.right, cur, pLen + 1)

        cur[n.val - 1] -= 1

        return r

    def pseudoPalindromicPaths(self, root: Optional[TreeNode]) -> int:
        initC = [0] * 9
        return self.dfs(root, initC, 0)


class Soln_Bit_manipulation:
    def dfs(self, n: TreeNode, mask: int):
        if n == None:
            return 0

        mask ^= 1 << int(n.val)

        if n.left == None and n.right == None:
            return 1 if (mask & (mask - 1)) == 0 else 0

        return self.dfs(n.left, mask) + self.dfs(n.right, mask)

    def pseudoPalindromicPaths(self, root: Optional[TreeNode]) -> int:
        return self.dfs(root, 0)


def Main():
    input = [2, 3, 1, 3, 1, None, 1]

    root = Utils.TreeOperations.generate(Utils.TreeOperations, input)

    s = Solution()

    print(s.pseudoPalindromicPaths(root))


if __name__ == "__main__":
    Main()

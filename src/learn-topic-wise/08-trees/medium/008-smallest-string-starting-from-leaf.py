# https://leetcode.com/problems/smallest-string-starting-from-leaf/description/

from typing import List, Optional
from utils.generate_trees import Utils, TreeNode


class Solution:
    res = ""

    def dfs(self, n: TreeNode, cur: str):
        cur = chr(ord('a') + n.val) + cur

        if n.left == None and n.right == None:
            if self.res == "" or self.res > cur:
                self.res = cur
        else:
            if n.left != None:
                self.dfs(n.left, cur)

            if n.right != None:
                self.dfs(n.right, cur)

    def smallestFromLeaf(self, root: Optional[TreeNode]) -> str:
        self.dfs(root, "")
        return self.res


def Main():
    input = [0, 1, 2, 3, 4, 3, 4]

    root = Utils.TreeOperations.generate(Utils.TreeOperations, input)

    s = Solution()

    print(s.smallestFromLeaf(root))


if __name__ == '__main__':
    Main()

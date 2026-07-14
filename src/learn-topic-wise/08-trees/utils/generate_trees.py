from typing import List


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Utils:
    class TreeOperations:
        def generate(self, arr: List[int]) -> TreeNode:
            if arr[0] == None:
                return None

            n = len(arr)

            root = TreeNode(arr[0])

            i = 1
            q = [root]
            while len(q) > 0 and i < n:
                cur = q.pop(0)

                if arr[i] != None:
                    cur.left = TreeNode(arr[i])
                    q.append(cur.left)
                i += 1

                if i < n and arr[i] != None:
                    cur.right = TreeNode(arr[i])
                    q.append(cur.right)
                i += 1

            return root

        def find(self, root: TreeNode, val: int) -> TreeNode:

            return root

        def print(self, root: TreeNode) -> None:
            if root == None:
                return

            print(root.val)

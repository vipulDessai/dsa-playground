from typing import List

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Utils:
    class TreeOperations:
        def generate(self, arr: List[int]) -> TreeNode:
            root = TreeNode(arr[0])

            return root
        
        def find(self, root: TreeNode, val: int) -> TreeNode:

            return root
        
        def print(self, root: TreeNode) -> None:
            if(root == None): return

            print(root.val)
            


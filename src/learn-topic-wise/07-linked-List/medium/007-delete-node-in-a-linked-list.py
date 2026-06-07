# [Delete Node in a Linked List](https://leetcode.com/problems/delete-node-in-a-linked-list/)

from utils.generate_linked_list import Utils


class Solution:
    def deleteNode(self, node):
        """
        :type node: ListNode
        :rtype: void Do not return anything, modify node in-place instead.
        """
        node.val = node.next.val
        node.next = node.next.next

        return node


def Main():
    input = [4, 5, 1, 9]
    nodeInd = 1

    inputList = Utils.Generate(Utils, input)
    delNode = inputList
    while nodeInd > 0:
        delNode = delNode.next
        nodeInd -= 1

    sol = Solution()
    sol.deleteNode(delNode)

    while inputList != None:
        print(inputList.val)
        inputList = inputList.next


if __name__ == "__main__":
    Main()

from typing import List


class Utils:
    class ListNode:
        def __init__(self, x):
            self.val = x
            self.next = None

    def Generate(self, arr: List[int]) -> ListNode:
        head = self.ListNode(arr[0])
        next = head

        for val in arr[1:]:
            next.next = self.ListNode(val)
            next = next.next

        return head

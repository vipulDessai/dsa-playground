export const url =
  '[Linked List Cycle](https://leetcode.com/problems/linked-list-cycle/)';

class ListNode {
  val: number;
  next: ListNode | null;
  constructor(val?: number, next?: ListNode | null) {
    this.val = val === undefined ? 0 : val;
    this.next = next === undefined ? null : next;
  }
}

function hasCycle(head: ListNode | null): boolean {
  let s = head,
    f = head;

  while (f && f.next) {
    s = s!.next;
    f = f.next.next;

    if (f === s) return true;
  }

  return false;
}

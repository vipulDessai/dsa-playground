import { LinkedList, ListNode } from './utils/generate-linked-list';

var myLinkedList = new LinkedList([1, 2, 3, 4]);
const reversedList = reverseList(myLinkedList.singlyList);
console.log(reversedList);

function reverseList_iterative(head: ListNode | null): ListNode | null {
  let prev: ListNode | null = null,
    curr = head;

  while (curr) {
    let nxt = curr.next;
    [curr.next, prev] = [prev, curr];

    curr = nxt;
  }

  return prev;
}

function reverseList(head: ListNode | null): ListNode | null {
  function reverse(
    cur: ListNode | null,
    prev: ListNode | null,
  ): ListNode | null {
    if (!cur) {
      return prev;
    } else {
      const next = cur.next;
      cur.next = prev;

      return reverse(next, cur);
    }
  }

  return reverse(head, null);
}

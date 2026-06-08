import { LinkedList, ListNode } from './utils/generate-linked-list';

var l1 = new LinkedList([1, 2, 3, 4]);
var l2 = new LinkedList([1, 2, 3, 4]);
const mergedList = mergeTwoLists(l1.singlyList, l2.singlyList);
console.log(mergedList);

function mergeTwoLists(
  list1: ListNode | null,
  list2: ListNode | null,
): ListNode | null {
  let head = new ListNode();
  let tail = head;

  while (list1 && list2) {
    if (list1.val < list2.val) {
      tail.next = list1;
      list1 = list1.next;
    } else {
      tail.next = list2;
      list2 = list2.next;
    }

    tail = tail.next;
  }

  if (list1) {
    tail.next = list1;
  }

  if (list2) {
    tail.next = list2;
  }

  return head.next;
}

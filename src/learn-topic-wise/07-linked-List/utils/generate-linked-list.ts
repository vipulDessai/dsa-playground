// Definition for singly-linked list.
export class ListNode {
  val: number;
  next: ListNode | null;
  constructor(val?: number, next?: ListNode | null) {
    this.val = val === undefined ? 0 : val;
    this.next = next === undefined ? null : next;
  }
}

export class LinkedList {
  #internalLinkedList: ListNode | null;
  get singlyList() {
    return this.#internalLinkedList;
  }
  constructor(arr: number[]) {
    if (arr.length === 0) this.#internalLinkedList = null;

    this.#internalLinkedList = new ListNode(arr[0]);

    this.#buildList(arr);
  }
  #buildList(arr: number[]) {
    let cur = this.#internalLinkedList;
    let i = 1;
    while (cur) {
      const nextArrItem = arr[i];
      if (nextArrItem) {
        cur.next = new ListNode(nextArrItem, null);
      }

      cur = cur.next;
      i++;
    }
  }
}

var myLinkedList = new LinkedList([1]);
console.log(myLinkedList.singlyList);

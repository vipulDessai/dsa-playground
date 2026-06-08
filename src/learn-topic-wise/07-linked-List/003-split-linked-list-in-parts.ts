// https://leetcode.com/problems/split-linked-list-in-parts

/**
 * Definition for singly-linked list.
 * class ListNode {
 *     val: number
 *     next: ListNode | null
 *     constructor(val?: number, next?: ListNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */

import { ListNode } from './utils/generate-linked-list';

function splitListToParts(
  head: ListNode | null,
  k: number,
): Array<ListNode | null> {
  let n = 0;

  let nxtPtrNode = head;
  while (nxtPtrNode) {
    n++;
    nxtPtrNode = nxtPtrNode.next;
  }

  let s = (n - (n % k)) / k;
  let firstParts = n % k;

  const res: Array<ListNode | null> = [];
  nxtPtrNode = head;
  while (firstParts) {
    let c = 0;
    let curHeadNode = nxtPtrNode;
    while (c < s + 1 && nxtPtrNode) {
      nxtPtrNode = nxtPtrNode.next;
      ++c;
    }

    let t = null;
    if (nxtPtrNode && nxtPtrNode.next) {
      t = nxtPtrNode.next;
      nxtPtrNode.next = null;
    }

    nxtPtrNode = t;
    res.push(curHeadNode);
    --firstParts;
  }

  while (n) {
    let c = 0;
    let curHeadNode = nxtPtrNode;
    while (c < s && nxtPtrNode) {
      nxtPtrNode = nxtPtrNode.next;
      ++c;
    }

    let t = null;
    if (nxtPtrNode && nxtPtrNode.next) {
      t = nxtPtrNode.next;
      nxtPtrNode.next = null;
    }

    nxtPtrNode = t;
    res.push(curHeadNode);
    --n;
  }

  return res;
}

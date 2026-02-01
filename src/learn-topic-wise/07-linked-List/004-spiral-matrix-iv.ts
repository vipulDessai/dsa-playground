export const url =
  '[Spiral Matrix IV](https://leetcode.com/problems/spiral-matrix-iv/description/)';

import { LinkedList } from './000-linked-list-from-array';
import type { ListNode } from './000-linked-list-from-array';

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

function spiralMatrix(m: number, n: number, head: ListNode | null): number[][] {
  const matrix = Array.from({ length: m }, () => Array(n).fill(0));
  let l = 0,
    r = n - 1,
    u = 0,
    b = m - 1;

  while (l <= r && u <= b) {
    for (let i = l; i <= r; ++i) {
      if (head) {
        matrix[u][i] = head.val;
        head = head.next;
      } else {
        matrix[u][i] = -1;
      }
    }
    ++u;

    for (let i = u; i <= b; ++i) {
      if (head) {
        matrix[i][r] = head.val;
        head = head.next;
      } else {
        matrix[i][r] = -1;
      }
    }
    --r;

    if (u <= b) {
      for (let i = r; i >= l; --i) {
        if (head) {
          matrix[b][i] = head.val;
          head = head.next;
        } else {
          matrix[b][i] = -1;
        }
      }
      --b;
    }

    if (l <= r) {
      for (let i = b; i >= u; --i) {
        if (head) {
          matrix[i][l] = head.val;
          head = head.next;
        } else {
          matrix[i][l] = -1;
        }
      }
      ++l;
    }
  }

  return matrix;
}

var r = 3,
  c = 5,
  l = new LinkedList([3, 0, 2, 6, 8, 1, 7, 9, 4, 2, 5, 5, 0]);

var r = 1,
  c = 4,
  l = new LinkedList([0, 1, 2]);

var out = spiralMatrix(r, c, l.singlyList);
console.log(out);

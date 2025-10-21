export const url =
  '[remove stones to minimize the total](https://leetcode.com/problems/remove-stones-to-minimize-the-total/)';

type MaxHeapMinStoneType = {
  val: number;
  p: number;
};
class MaxHeapMinStone {
  queue: MaxHeapMinStoneType[] = [];

  getParent(i: number) {
    return Math.floor((i - 1) / 2);
  }

  getLeftChild(i: number) {
    return i * 2 + 1;
  }
  getRightChild(i: number) {
    return i * 2 + 2;
  }

  heapifyUp() {
    let i = this.queue.length - 1,
      pI = this.getParent(i);

    while (pI >= 0 && this.queue[i].p > this.queue[pI].p) {
      [this.queue[i], this.queue[pI]] = [this.queue[pI], this.queue[i]];

      i = pI;
      pI = this.getParent(i);
    }
  }
  enqueue(val: number) {
    this.queue.push({ val, p: val });
    this.heapifyUp();
  }

  heapifyDown() {
    const n = this.queue.length;
    let i = 0,
      lI = this.getLeftChild(i);

    while (lI < n) {
      let j = lI;

      const rI = this.getRightChild(i);
      if (rI < n && this.queue[rI].p > this.queue[j].p) {
        j = rI;
      }

      if (this.queue[j].p > this.queue[i].p) {
        [this.queue[i], this.queue[j]] = [this.queue[j], this.queue[i]];

        i = j;
        lI = this.getLeftChild(i);
      } else {
        break;
      }
    }
  }
  dequeue() {
    const n = this.queue.length;

    if (n === 0) {
      return null;
    }

    if (n === 1) {
      return this.queue.pop();
    }

    const res = this.queue[0];
    this.queue[0] = this.queue.pop()!;
    this.heapifyDown();

    return res;
  }

  get size() {
    return this.queue.length;
  }
}

function minStoneSum(piles: number[], k: number): number {
  const pQ = new MaxHeapMinStone();

  for (const num of piles) {
    pQ.enqueue(num);
  }

  while (k > 0) {
    const { val, p } = pQ.dequeue()!;
    const remCount = Math.floor(val / 2);

    pQ.enqueue(val - remCount);

    --k;
  }

  let res = 0;
  while (pQ.size > 0) {
    const { val, p } = pQ.dequeue()!;
    res += val;
  }

  return res;
}

var p = [],
  k = 0;
var out = minStoneSum(p, k);

console.log(out);

export const url = 'https://leetcode.com/problems/relative-ranks/description/';

type RelativeRanksMinHeapType = {
  v: number;
  p: number;
};

class RelativeRanksMinHeap {
  queue: RelativeRanksMinHeapType[] = [];

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
  enqueue(v: number, p: number) {
    this.queue.push({ v, p });
    this.heapifyUp();
  }

  heapifyDown() {
    const n = this.queue.length;

    let i = 0,
      j = this.getLeftChild(i);
    while (j < n) {
      const rI = this.getRightChild(i);

      if (rI < n && this.queue[rI].p > this.queue[j].p) {
        j = rI;
      }

      if (this.queue[j].p > this.queue[i].p) {
        [this.queue[i], this.queue[j]] = [this.queue[j], this.queue[i]];

        i = j;
        j = this.getLeftChild(i);
      } else {
        break;
      }
    }
  }
  dequeue() {
    const n = this.size;

    if (n === 0) return null;
    if (n === 1) return this.queue.pop();

    const res = this.queue[0];
    this.queue[0] = this.queue.pop()!;
    this.heapifyDown();
    return res;
  }

  get size() {
    return this.queue.length;
  }
}

function findRelativeRanks(score: number[]): string[] {
  const pQ = new RelativeRanksMinHeap();

  const n = score.length;

  for (let i = 0; i < n; i++) {
    pQ.enqueue(i, score[i]);
  }

  const res = Array(n).fill('');
  let rank = 0;
  while (pQ.size > 0) {
    const { v: i, p } = pQ.dequeue()!;

    if (rank === 0) {
      res[i] = 'Gold Medal';
    } else if (rank === 1) {
      res[i] = 'Silver Medal';
    } else if (rank === 2) {
      res[i] = 'Bronze Medal';
    } else {
      res[i] = (rank + 1).toString();
    }

    ++rank;
  }
  return res;
}

var input = [];
var out = findRelativeRanks(input);

console.log(out);

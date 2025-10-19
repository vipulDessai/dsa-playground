export const url =
  '[maximum average pass ratio](https://leetcode.com/problems/maximum-average-pass-ratio/)';

type MaxHeapMaxAvgPassRatioType = {
  val: number[];
  p: number;
};
class MaxHeapMaxAvgPassRatio {
  queue: MaxHeapMaxAvgPassRatioType[] = [];

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
    let i = this.queue.length - 1;
    let parentIndex = this.getParent(i);

    while (parentIndex >= 0 && this.queue[i].p > this.queue[parentIndex].p) {
      [this.queue[i], this.queue[parentIndex]] = [
        this.queue[parentIndex],
        this.queue[i],
      ];

      i = parentIndex;
      parentIndex = this.getParent(i);
    }
  }

  enqueue(item: number[], p: number) {
    this.queue.push({ val: item, p });
    this.heapifyUp();
  }

  heapifyDown() {
    const n = this.queue.length;
    let i = 0;
    let j = this.getLeftChild(i);
    while (j < n) {
      const rightChildIndex = this.getRightChild(i);

      if (
        rightChildIndex < n &&
        this.queue[rightChildIndex].p > this.queue[j].p
      ) {
        j = rightChildIndex;
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

function maxAverageRatio(classes: number[][], extraStudents: number): number {
  const n = classes.length;

  const pQ = new MaxHeapMaxAvgPassRatio();

  const gain = (pass: number, total: number): number =>
    (pass + 1) / (total + 1) - pass / total;

  for (const [pass, total] of classes) {
    pQ.enqueue([pass, total], gain(pass, total));
  }

  while (extraStudents > 0) {
    const [pass, total] = pQ.dequeue()?.val!;
    pQ.enqueue([pass + 1, total + 1], gain(pass + 1, total + 1));

    --extraStudents;
  }

  let res = 0;
  while (pQ.size) {
    const [pass, total] = pQ.dequeue()?.val!;
    res += pass / total;
  }
  return res / n;
}

var input = [
    [1, 2],
    [3, 5],
    [2, 2],
  ],
  e = 2;
var out = maxAverageRatio(input, e);

console.log(out);

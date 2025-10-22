export const url =
  '[furthest building you can reach](https://leetcode.com/problems/furthest-building-you-can-reach/)';

type MinHeapFurthestBuildingType = {
  val: number;
  p: number;
};

class MinHeapFurthestBuilding {
  queue: MinHeapFurthestBuildingType[] = [];

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

    while (pI >= 0 && this.queue[pI].p < this.queue[i].p) {
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
      j = this.getLeftChild(i);

    while (j < n) {
      const rI = this.getRightChild(i);

      if (rI < n && this.queue[rI].p < this.queue[j].p) {
        j = rI;
      }

      if (this.queue[j].p < this.queue[i].p) {
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
      return this.queue.pop()!;
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

function furthestBuilding(
  heights: number[],
  bricks: number,
  ladders: number,
): number {
  let n = heights.length;
  var pQ = new MinHeapFurthestBuilding();

  for (let i = 1; i < n; i++) {
    let cur = heights[i] - heights[i - 1];

    if (cur > 0) {
      pQ.enqueue(cur);

      // check if all ladders are used
      if (pQ.size > ladders) {
        const { p, val } = pQ.dequeue()!;
        bricks -= val;
        if (bricks < 0) {
          return i - 1;
        }
      }
    }
  }

  return n - 1;
}

var input = [4, 2, 7, 6, 9, 14, 12],
  b = 5,
  l = 1;
var output = furthestBuilding(input, b, l);

console.log(output);

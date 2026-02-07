type pqType = {
  v: number;
  p: number;
};

class PQTopKFrequent {
  q: pqType[] = [];

  getParent(i: number) {
    return Math.floor((i - 1) / 2);
  }

  getLeftChild(i: number) {
    return 2 * i + 1;
  }
  getRightChild(i: number) {
    return 2 * i + 2;
  }

  enqueue(v: number, p: number) {
    this.q.push({ v, p });

    const n = this.q.length;
    let i = n - 1,
      pI = this.getParent(i);

    while (pI >= 0 && this.q[i].p > this.q[pI].p) {
      [this.q[i], this.q[pI]] = [this.q[pI], this.q[i]];

      i = pI;
      pI = this.getParent(i);
    }
  }

  heapifyDown() {
    const n = this.q.length;
    let i = 0,
      j = this.getLeftChild(i);

    while (j < n) {
      const rI = this.getRightChild(i);

      if (rI < n && this.q[rI].p > this.q[j].p) {
        j = rI;
      }

      if (this.q[j].p > this.q[i].p) {
        [this.q[j], this.q[i]] = [this.q[i], this.q[j]];

        i = j;
        j = this.getLeftChild(i);
      } else {
        break;
      }
    }
  }

  dequeue() {
    const n = this.q.length;

    if (n == 0) {
      return null;
    }

    if (n == 1) {
      return this.q.pop()!.v;
    }

    const res = this.q[0];
    this.q[0] = this.q.pop()!;
    this.heapifyDown();
    return res.v;
  }
}

function topKFrequent(nums: number[], k: number): number[] {
  const freq = nums.reduce((acc, cur) => {
    acc.set(cur, (acc.get(cur) || 0) + 1);

    return acc;
  }, new Map<number, number>());

  const pQ = new PQTopKFrequent();
  for (const [_k, _v] of freq) {
    pQ.enqueue(_k, _v);
  }

  const res: number[] = [];
  for (let i = 0; i < k; ++i) {
    res.push(pQ.dequeue()!);
  }

  return res;
}

function topKFrequent(numsList: number[], k: number): number[] {
  const count = {};
  const freq: number[][] = [];
  for (let index = 0; index < numsList.length; index++) {
    freq.push([]);
  }

  for (let index = 0; index < numsList.length; index++) {
    const num = numsList[index];
    count[num] = 1 + (count[num] || 0);
  }

  Object.entries(count).forEach(([key, value]: [string, unknown]) => {
    freq[value as number].push(parseInt(key));
  });

  const topK: number[] = [];
  for (let index = freq.length - 1; index >= 0; --index) {
    const groupedNumsArray: number[] = freq[index];
    for (let j = 0; j < groupedNumsArray.length; j++) {
      topK.push(groupedNumsArray[j]);
      if (topK.length === k) {
        return topK;
      }
    }
  }

  return [];
}

console.log(topKFrequent([6, 9, 9, 2, 2], 2));

class PQTopKFrequent {
  private q: { p: number; v: number }[] = [];

  getLeftChild(i: number) {
    return 2 * i + 1;
  }

  getRightChild(i: number) {
    return 2 * i + 2;
  }

  getParent(i: number) {
    return Math.floor((i - 1) / 2);
  }

  heapifyUp() {
    let i = this.q.length - 1,
      pI = this.getParent(i);

    while (pI >= 0 && this.q[pI].p < this.q[i].p) {
      [this.q[pI], this.q[i]] = [this.q[i], this.q[pI]];
      i = pI;
      pI = this.getParent(i);
    }
  }

  enqueue(item: number) {
    this.q.push({ p: item, v: item });
    this.heapifyUp();
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

      if (this.q[i].p < this.q[j].p) {
        [this.q[i], this.q[j]] = [this.q[j], this.q[i]];

        i = j;
        j = this.getLeftChild(i);
      } else {
        break;
      }
    }
  }

  dequeue() {
    if (this.q.length === 0) {
      return null;
    }

    if (this.q.length === 1) {
      return this.q.pop()!.v;
    }

    const r = this.q[0];
    this.q[0] = this.q.pop()!;
    this.heapifyDown();
    return r.v;
  }
}

function topKFrequent_pQ(numsList: number[], k: number): number[] {
  // TODO
  return [];
}

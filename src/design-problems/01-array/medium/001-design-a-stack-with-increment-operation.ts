// https://leetcode.com/problems/design-a-stack-with-increment-operation/?envType=daily-question&envId=2024-09-30

class CustomStack {
  n: number;
  inc: number[];
  stack: number[];
  constructor(maxSize: number) {
    this.n = maxSize;
    this.inc = new Array(maxSize);
    this.stack = [];
  }

  push(x: number): void {
    if (this.stack.length < this.n) this.stack.push(x);
  }

  pop(): number {
    const i = this.stack.length - 1;

    if (i < 0) return -1;

    if (i > 0) this.inc[i - 1] += this.inc[i];

    const cur = this.stack.pop();

    if (cur) {
      const res = cur + this.inc[i];
      this.inc[i] = 0;
      return res;
    } else {
      return -1;
    }
  }

  increment(k: number, val: number): void {
    const i = Math.min(k, this.stack.length) - 1;
    if (i >= 0) this.inc[i] += val;
  }
}

/**
 * Your CustomStack object will be instantiated and called as such:
 * var obj = new CustomStack(maxSize)
 * obj.push(x)
 * var param_2 = obj.pop()
 * obj.increment(k,val)
 */

const inActions = [
  'CustomStack',
  'push',
  'push',
  'pop',
  'push',
  'push',
  'push',
  'increment',
  'increment',
  'pop',
  'pop',
  'pop',
  'pop',
];
const inValues = [
  [3],
  [1],
  [2],
  [],
  [2],
  [3],
  [4],
  [5, 100],
  [2, 100],
  [],
  [],
  [],
  [],
];

const cS = new CustomStack(inValues[0][0]);
for (let i = 1; i < inActions.length; ++i) {
  switch (inActions[i]) {
    case 'push':
      cS.push(inValues[i][0]);
      break;

    case 'pop':
      cS.pop();
      break;

    case 'inc':
      cS.increment(inValues[i][0], inValues[i][1]);
      break;

    default:
      break;
  }
}

export const trickToCreateJsModule = '';

export const url = "[Min Stack](https://leetcode.com/problems/min-stack/description/)"

class MinStack {
  stack: number[];
  minStack: number[];
  constructor() {
    this.stack = [];
    this.minStack = [];
  }

  push(val: number): void {
    this.stack.push(val);

    const minVal = Math.min(
      val,
      this.minStack.length ? this.minStack[this.minStack.length - 1] : val,
    );
    this.minStack.push(minVal);
  }

  pop(): void {
    this.minStack.pop();
    this.stack.pop();
  }

  top(): number {
    return this.stack[this.stack.length - 1];
  }

  getMin(): number {
    return this.minStack[this.minStack.length - 1];
  }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * var obj = new MinStack()
 * obj.push(val)
 * obj.pop()
 * var param_3 = obj.top()
 * var param_4 = obj.getMin()
 */

var obj = new MinStack();
obj.push(0);
obj.push(1);
obj.push(0);
console.log(obj.getMin());
obj.pop();
console.log(obj.getMin());

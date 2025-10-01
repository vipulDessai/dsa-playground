export const url =
  '[The k Strongest Values in an Array](https://leetcode.com/problems/the-k-strongest-values-in-an-array/description/)';

function getStrongest(arr: number[], k: number): number[] {
  const n = arr.length;
  arr.sort((a, b) => a - b);

  const mInd = Math.floor((n - 1) / 2);
  const m = arr[mInd];

  arr.sort((a, b) => {
    const _a = Math.abs(a - m);
    const _b = Math.abs(b - m);

    if (_a === _b) {
      return a - b;
    }

    return _a - _b;
  });

  const res: number[] = [];
  for (let i = 0; i < k; ++i) {
    res.push(arr.pop()!);
  }

  return res;
}

var input = [],
  k = 0;
var out = getStrongest(input, k);

console.log(out);

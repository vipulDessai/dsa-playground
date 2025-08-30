export const url =
  '[Maximum erasure value](https://leetcode.com/problems/maximum-erasure-value/)';

function maximumUniqueSubarray(nums: number[]): number {
  const n = nums.length;

  let sum = 0,
    res = 0,
    l = 0,
    r = 0;
  const uMap = new Map<number, number>();
  while (r < n) {
    const rVal = nums[r];
    sum += rVal;

    let rCount = uMap.get(rVal);
    if (typeof rCount === 'number') {
      uMap.set(rVal, rCount + 1);
    } else {
      uMap.set(rVal, 1);
    }

    while (r - l + 1 > uMap.size) {
      const lVal = nums[l];
      sum -= lVal;
      let lCount = uMap.get(lVal)!;
      --lCount;

      if (lCount > 0) {
        uMap.set(lVal, lCount);
      } else {
        uMap.delete(lVal);
      }

      ++l;
    }

    res = Math.max(res, sum);

    ++r;
  }

  return res;
}

var input = [5, 2, 1, 2, 5, 2, 1, 2, 5];
var out = maximumUniqueSubarray(input);

console.log(out);

export const url =
  '[Degree of an Array](https://leetcode.com/problems/degree-of-an-array/)';

function findShortestSubArray(nums: number[]): number {
  const countMap = new Map<number, number>();
  const firstIndexMap = new Map<number, number>();
  const lastIndexMap = new Map<number, number>();

  for (let i = 0; i < nums.length; i++) {
    const num = nums[i];
    if (!firstIndexMap.has(num)) {
      firstIndexMap.set(num, i);
    }
    lastIndexMap.set(num, i);
    countMap.set(num, (countMap.get(num) || 0) + 1);
  }

  const degree = Math.max(...countMap.values());
  let minLength = nums.length;

  for (const [num, freq] of countMap.entries()) {
    if (freq === degree) {
      const length = lastIndexMap.get(num)! - firstIndexMap.get(num)! + 1;
      minLength = Math.min(minLength, length);
    }
  }

  return minLength;
}

var input = [1, 2, 2, 3, 1, 4, 2];
var out = findShortestSubArray(input);

console.log(out);

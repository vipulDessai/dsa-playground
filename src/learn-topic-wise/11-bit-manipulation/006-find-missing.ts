export const url =
  '[Missing Number](https://leetcode.com/problems/missing-number/)';

function missingNumber(nums: number[]): number {
  const n = nums.length;

  let bits = 0;
  // from 0 -> n, not n - 1
  for (let i = 0; i <= n; ++i) {
    bits ^= i;
  }
  for (let i = 0; i < n; ++i) {
    bits ^= nums[i];
  }

  return bits;
}

var input = [1, 2, 3];
var out = missingNumber(input);

console.log(out);

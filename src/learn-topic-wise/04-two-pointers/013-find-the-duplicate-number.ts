export const url =
  '[Find the Duplicate Number](https://leetcode.com/problems/find-the-duplicate-number/description/)';

// detects the cycle and finds the entry point
function findDuplicate(nums: number[]): number {
  let s = nums[0],
    f = nums[nums[0]];

  // 1. find the cycle
  while (s !== f) {
    s = nums[s];
    f = nums[nums[f]];
  }

  // 2. find the entry point
  f = nums[0];
  s = nums[s];
  while (s !== f) {
    s = nums[s];
    f = nums[f];
  }

  return s;
}

var input = [1, 3, 4, 2, 2];
var out = findDuplicate(input);

console.log(out);

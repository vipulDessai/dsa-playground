export const url =
  '[Max Consecutive Ones I](https://leetcode.com/problems/max-consecutive-ones/)';

function findMaxConsecutiveOnes(nums: number[]): number {
  const n = nums.length;
  let l = 0,
    r = 0,
    res = 0;

  while (r < n) {
    if (nums[r] === 0) {
      res = Math.max(res, r - l);
      l = r + 1;
    }

    ++r;
  }

  res = Math.max(res, r - l);

  return res;
}

var input = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0];
var out = findMaxConsecutiveOnes(input);

console.log(out);

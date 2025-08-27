export const url =
  '[Max Consecutive Ones III](https://leetcode.com/problems/max-consecutive-ones-iii/description/)';

function longestOnes(nums: number[], k: number): number {
  const n = nums.length;

  let l = 0,
    r = 0,
    res = 0,
    zCount = 0;
  while (r < n) {
    if (nums[r] === 0) {
      ++zCount;
    }

    while (zCount > k) {
      if (nums[l] === 0) {
        --zCount;
      }

      ++l;
    }

    res = Math.max(res, r - l + 1);

    ++r;
  }

  return res;
}

var input = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0];
var k = 2;

input = [0, 0, 1, 1, 0, 0, 0, 1, 1, 1];
k = 4;

var out = longestOnes(input, k);
console.log(out);

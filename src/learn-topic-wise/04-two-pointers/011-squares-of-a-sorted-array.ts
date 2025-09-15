export const url =
  '[squares-of-a-sorted-array](https://leetcode.com/problems/squares-of-a-sorted-array/description/)';

function sortedSquares(nums: number[]): number[] {
  const n = nums.length,
    res = Array(n).fill(0);

  let l = 0,
    r = n - 1,
    i = n - 1;
  while (l <= r) {
    if (Math.abs(nums[l]) > Math.abs(nums[r])) {
      res[i] = nums[l] * nums[l];
      ++l;
    } else {
      res[i] = nums[r] * nums[r];
      --r;
    }

    --i;
  }

  return res;
}

var input = [-4, -1, 0, 3, 10];
var input = [-7, -3, 2, 3, 11];

var out = sortedSquares(input);

console.log(out);

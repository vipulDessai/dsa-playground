export const url =
  '[Rotate Array](https://leetcode.com/problems/rotate-array/description/)';

/**
 Do not return anything, modify nums in-place instead.
 */
function reverse(l: number, r: number, nums: number[]) {
  while (l < r) {
    [nums[l], nums[r]] = [nums[r], nums[l]];

    ++l;
    --r;
  }
}

function rotate(nums: number[], k: number): void {
  const n = nums.length;

  reverse(0, n - 1, nums);
  reverse(0, (k % n) - 1, nums);
  reverse(k % n, n - 1, nums);
}

var input = [],
  k = 0;
rotate(input, k);

console.log('foo');

export const url =
  '[Find Minimum in Rotated Sorted Array](https://leetcode.com/problems/find-minimum-in-rotated-sorted-array)';

function findMin(nums: number[]): number {
  const n = nums.length;

  let l = 0,
    r = n - 1;
  while (l < r) {
    const m = Math.floor(l + (r - l) / 2);

    if (nums[m] <= nums[r]) {
      r = m;
    } else {
      l = m + 1;
    }
  }

  return nums[r];
}

var input = [2, 1];
var out = findMin(input);

console.log(out);

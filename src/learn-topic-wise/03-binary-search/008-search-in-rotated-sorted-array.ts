export const url =
  '[Search in Rotated Sorted Array](https://leetcode.com/problems/search-in-rotated-sorted-array/description/)';

function search(nums: number[], target: number): number {
  const n = nums.length;
  let l = 0,
    r = n - 1;

  while (l <= r) {
    const m = Math.floor(l + (r - l) / 2);

    if (nums[m] === target) return m;

    if (nums[l] <= nums[m]) {
      if (target >= nums[l] && target < nums[m]) {
        r = m - 1;
      } else {
        l = m + 1;
      }
    } else {
      if (target > nums[m] && target <= nums[r]) {
        l = m + 1;
      } else {
        r = m - 1;
      }
    }
  }

  return -1;
}

var nums = [4, 5, 6, 7, 0, 1, 2, 3],
  target = 0;
console.log(search(nums, target));

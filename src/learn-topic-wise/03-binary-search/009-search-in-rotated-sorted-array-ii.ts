export const url =
  'https://leetcode.com/problems/search-in-rotated-sorted-array-ii/description/';

function search(nums: number[], target: number): boolean {
  let l = 0,
    r = nums.length - 1;

  while (l <= r) {
    const m = Math.floor(l + (r - l) / 2);

    if (nums[m] === target) return true;

    if (nums[l] === nums[m]) {
      ++l;
    } else if (nums[r] === nums[m]) {
      --r;
    } else {
      if (nums[l] <= nums[m]) {
        if (target >= nums[l] && target <= nums[m]) {
          r = m - 1;
        } else {
          l = m + 1;
        }
      } else {
        if (target >= nums[m] && target <= nums[r]) {
          l = m + 1;
        } else {
          r = m - 1;
        }
      }
    }
  }

  return false;
}

// var nums = [2, 5, 5, 6, 0, 0, 1, 2],
//   target = 3;
// console.log(search(nums, target));

// var nums = [1, 1, 1, 1, 2, 1, 1],
//   target = 2;
// console.log(search(nums, target));

var nums = [3, 5, 1],
  target = 1;

nums = [2, 5, 6, 0, 0, 1, 2];
target = 2;
console.log(search(nums, target));

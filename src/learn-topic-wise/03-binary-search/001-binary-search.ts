export const url =
  '[Search Insert Position](https://leetcode.com/problems/search-insert-position/description/)';

function searchInsert(nums: number[], target: number): number {
  let l = 0,
    r = nums.length;

  // its less than or equal to because the
  // array could be of length 1
  // so the mid (m) should be calculated properly
  while (l < r) {
    const m = Math.floor(l + (r - l) / 2);

    if (nums[m] >= target) {
      r = m;
    } else {
      l = m + 1;
    }
  }

  return l;
}

console.log(searchInsert([1, 3, 5, 6], 5));
console.log(searchInsert([1, 3, 5, 6], 2));
console.log(searchInsert([1, 3, 5, 6], 7));

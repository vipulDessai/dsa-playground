export const url =
  "[Longest Subarray of 1's After Deleting One Element](https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/description/)";

function longestSubarray(nums: number[]): number {
  const n = nums.length;

  let l = 0,
    r = 0,
    res = 0,
    zCount = 0;
  while (r < n) {
    if (nums[r] === 0) {
      ++zCount;
    }

    while (zCount > 1) {
      if (nums[l] === 0) {
        --zCount;
      }

      ++l;
    }

    res = Math.max(res, r - l);

    ++r;
  }

  return res;
}

var input = [0, 1, 1, 1, 0, 1, 1, 0, 1];

input = [1, 1, 1];

var out = longestSubarray(input);
console.log(out);

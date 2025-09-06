export const url =
  '[Sort Array By Parity](https://leetcode.com/problems/sort-array-by-parity/description/)';

function sortArrayByParity(nums: number[]): number[] {
  const n = nums.length;
  let l = 0,
    r = 0;
  while (r < n) {
    if (nums[r] % 2 === 0) {
      [nums[r], nums[l]] = [nums[l], nums[r]];
      ++l;
    }

    ++r;
  }
  return nums;
}

var input = [3, 1, 2, 4];
var out = sortArrayByParity(input);

console.log(out);

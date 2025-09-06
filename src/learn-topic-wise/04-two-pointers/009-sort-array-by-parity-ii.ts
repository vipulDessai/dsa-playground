export const url =
  '[Sort Array By Parity II](https://leetcode.com/problems/sort-array-by-parity-ii/description/)';

function sortArrayByParityII(nums: number[]): number[] {
  const n = nums.length;

  let even = 0,
    odd = 1;
  while (even < n && odd < n) {
    // find next odd number at even index
    while (even < n && nums[even] % 2 === 0) {
      even += 2;
    }

    // find next even number at odd index
    while (odd < n && nums[odd] % 2 === 1) {
      odd += 2;
    }

    if (even < n && odd < n) {
      [nums[even], nums[odd]] = [nums[odd], nums[even]];
    }
  }

  return nums;
}

var input = [3, 1, 2, 4];
var out = sortArrayByParityII(input);

console.log(out);

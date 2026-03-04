export const url =
  '[Running Sum of 1d Array](https://leetcode.com/problems/running-sum-of-1d-array/description/)';

function runningSum(nums: number[]): number[] {
  let pSUm = 0;
  for (let i = 0; i < nums.length; ++i) {
    const t = nums[i];
    nums[i] = pSUm + t;
    pSUm += t;
  }
  return nums;
}

var input = [1, 2, 3, 4];
console.log(runningSum(input));

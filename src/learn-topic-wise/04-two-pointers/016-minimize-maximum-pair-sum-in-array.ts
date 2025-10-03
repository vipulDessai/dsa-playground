export const url =
  '[Minimize Maximum Pair Sum in Array](https://leetcode.com/problems/minimize-maximum-pair-sum-in-array/description/)';

function minPairSum(nums: number[]): number {
  nums.sort((a, b) => a - b);

  let i = 0,
    j = nums.length - 1,
    res = 0;
  while (i < j) {
    res = Math.max(res, nums[i] + nums[j]);

    ++i;
    --j;
  }

  return res;
}

var input = [9, 2, 10, 1, 10, 4, 8, 9, 7, 6, 8, 10, 8, 6, 5, 4, 3, 4, 2, 10];
var out = minPairSum(input);

console.log(out);

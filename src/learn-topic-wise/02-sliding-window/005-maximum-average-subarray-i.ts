export const url =
  '[Maximum Average Subarray I](https://leetcode.com/problems/maximum-average-subarray-i/)';

function findMaxAverage(nums: number[], k: number): number {
  const n = nums.length;
  let sum = 0;

  for (let i = 0; i < k; ++i) {
    sum += nums[i];
  }

  let res = sum / k,
    r = k;

  while (r < n) {
    sum -= nums[r - k];
    sum += nums[r];

    res = Math.max(res, sum / k);

    ++r;
  }

  return res;
}

var input = [],
  k = 0;
var out = findMaxAverage(input, k);

console.log(out);

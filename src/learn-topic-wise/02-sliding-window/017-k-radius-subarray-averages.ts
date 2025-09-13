export const url =
  '[K Radius Subarray Averages](https://leetcode.com/problems/k-radius-subarray-averages/description/)';

function getAverages(nums: number[], k: number): number[] {
  const n = nums.length,
    wLen = k + k + 1;

  const res = Array(n).fill(-1);

  let sum = 0;
  for (let i = 0; i < wLen; ++i) {
    sum += nums[i];
  }

  let l = 0,
    r = wLen - 1;
  while (r < n) {
    const i = l + k;
    res[i] = Math.floor(sum / wLen);

    sum -= nums[l];
    ++l;
    ++r;
    sum += nums[r];
  }

  return res;
}

var input = [],
  k = 0;
var out = getAverages(input, k);

console.log(out);

export const url =
  '[Minimum Difference Between Highest and Lowest of K Scores](https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/)';

function minimumDifference(nums: number[], k: number): number {
  const n = nums.length;
  nums.sort((a, b) => a - b);

  let l = 0,
    r = k - 1,
    min: number = Infinity;
  while (r < n) {
    min = Math.min(min, nums[r] - nums[l]);

    ++l;
    ++r;
  }

  return min;
}

var input = [12, 3, 7, 19, 5, 8, 25],
  k = 4;
var out = minimumDifference(input, k);

console.log(out);

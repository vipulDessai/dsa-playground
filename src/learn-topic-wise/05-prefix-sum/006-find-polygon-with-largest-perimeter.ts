export const url =
  '[Find Polygon With the Largest Perimeter](https://leetcode.com/problems/find-polygon-with-the-largest-perimeter/description/)';

function largestPerimeter_array(nums: number[]): number {
  nums.sort((a, b) => b - a);

  let sum = nums.reduce((acc, cur) => {
    return acc + cur;
  }, 0);

  let c = 0;
  for (const cur of nums) {
    if (sum - cur > cur) {
      ++c;
    } else {
      sum -= cur;
    }
  }

  return c >= 3 ? sum : -1;
}

var input = [1, 12, 1, 2, 5, 50, 3];
console.log(largestPerimeter_array(input));

function largestPerimeter_prefixSum(nums: number[]): number {
  nums.sort((a, b) => a - b);
  const prefixSum: number[] = new Array(nums.length).fill(0);
  prefixSum[0] = nums[0];

  for (let i = 1; i < nums.length; i++) {
    prefixSum[i] = prefixSum[i - 1] + nums[i];
  }

  for (let i = nums.length - 1; i >= 2; i--) {
    if (prefixSum[i - 1] > nums[i]) {
      return prefixSum[i];
    }
  }

  return -1;
}

var input = [1, 12, 1, 2, 5, 50, 3];
console.log(largestPerimeter_prefixSum(input));

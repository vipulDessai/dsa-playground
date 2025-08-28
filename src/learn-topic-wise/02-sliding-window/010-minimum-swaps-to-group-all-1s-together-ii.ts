export const url =
  "[Minimum Swaps to Group All 1's Together II](https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together-ii/)";

// this exampls is good for practicing sliding window with circular array
// also how to find a sub array with max number of continous 1s

function minSwaps(nums: number[]): number {
  let totalOnes = 0;

  // find the total number of ones
  for (const num of nums) {
    totalOnes += num;
  }

  const n = nums.length;
  let l = 0;
  let cur1 = 0,
    max1 = 0;

  // find a length of window in the array with max number of 1s
  for (let r = 0; r < 2 * n; ++r) {
    cur1 += nums[r % n];

    // always the window that we are looking for should be
    // less than total number of ones found in the entire array
    if (r - l + 1 > totalOnes) {
      cur1 -= nums[l % n];

      ++l;
    }

    max1 = Math.max(max1, cur1);
  }

  // the answer is
  // total 1s in the array - a window with highest number of 1s
  // Why? Because the rest of the window will be 0s that need to be swapped with 1s outside the window.
  return totalOnes - max1;
}

var input = [0, 1, 0, 1, 1, 0, 0];
var out = minSwaps(input);

console.log(out);

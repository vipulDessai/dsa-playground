export const url =
  '[Longest Subarray with Sum K](https://www.geeksforgeeks.org/problems/longest-sub-array-with-sum-k0809/1)';

// find max length of a subarray whose sum is equals to target
function largestSubArrayKSum(nums: number[], target: number): number {
  const sumMap = new Map();
  sumMap.set(0, -1);

  let max = 0,
    prefixSum = 0;
  for (let i = 0; i < nums.length; i++) {
    prefixSum += nums[i];

    if (sumMap.has(prefixSum - target)) {
      max = Math.max(max, i - sumMap.get(prefixSum - target));
    }

    // in case of finding only 1 largest subarray,
    // we store the first index where the current
    // prefix sum was found for the first time
    //
    // checking whether the current prefix sum is stored
    // or not is important otherwise it will override with the
    // most recent index, and result will the shortest subarray length
    if (!sumMap.has(prefixSum)) {
      sumMap.set(prefixSum, i);
    }
  }

  return max;
}

// console.log(largestSubArrayKSum([5, 1, 4, 3, -4, -1, 8, 23], 8));
console.log(largestSubArrayKSum([1, -1, 5, -2, 3], 3));

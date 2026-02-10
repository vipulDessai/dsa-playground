export const url = '[largest subarray with zero sum kadane algorithm]()';

function largestSubArray(nums: number[]): number {
  let max = 0,
    prefixSum = 0;

  const sumMap = new Map(),
    target = 0;
  sumMap.set(0, -1);

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

console.log(largestSubArray([1, -1, 3, 2, -2, -8, 1, 7, 10, 23]));

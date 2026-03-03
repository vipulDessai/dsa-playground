export const url =
  '[2970. Count the Number of Incremovable Subarrays I](https://leetcode.com/problems/count-the-number-of-incremovable-subarrays-i/description/)';

function incremovableSubarrayCount(nums: number[]): number {
  const n = nums.length;
  let count = 0;

  // Precompute prefix validity
  const prefixValid: boolean[] = Array(n).fill(false);
  prefixValid[0] = true;
  for (let i = 1; i < n; i++) {
    prefixValid[i] = prefixValid[i - 1] && nums[i] > nums[i - 1];
  }

  // Precompute suffix validity
  const suffixValid: boolean[] = Array(n).fill(false);
  suffixValid[n - 1] = true;
  for (let i = n - 2; i >= 0; i--) {
    suffixValid[i] = suffixValid[i + 1] && nums[i] < nums[i + 1];
  }

  // Try removing every subarray [i..j]
  for (let i = 0; i < n; i++) {
    for (let j = i; j < n; j++) {
      const leftOk = i === 0 || prefixValid[i - 1];
      const rightOk = j === n - 1 || suffixValid[j + 1];
      if (leftOk && rightOk) {
        if (i === 0 || j === n - 1 || nums[i - 1] < nums[j + 1]) {
          count++;
        }
      }
    }
  }

  return count;
}

var input = [6, 5, 7, 8];
console.log(incremovableSubarrayCount(input));

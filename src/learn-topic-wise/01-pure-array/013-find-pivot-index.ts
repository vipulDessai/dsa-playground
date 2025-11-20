export const url =
  'https://leetcode.com/problems/reshape-the-matrix/description/';

function pivotIndex(nums: number[]): number {
  const totalSum = nums.reduce((acc, cur) => acc + cur, 0);

  let lSum = 0;
  for (let i = 0; i < nums.length; ++i) {
    const rSum = totalSum - lSum - nums[i];

    if (lSum === rSum) {
      return i;
    }

    lSum += nums[i];
  }

  return -1;
}

var input = [1, 7, 3, 6, 5, 6];
var out = pivotIndex(input);

console.log(out);

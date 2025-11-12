export const url =
  'https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/';

function findDisappearedNumbers(nums: number[]): number[] {
  for (const num of nums) {
    const i = Math.abs(num) - 1;
    nums[i] = -1 * Math.abs(nums[i]);
  }

  const res: number[] = [];
  for (let i = 0; i < nums.length; ++i) {
    if (nums[i] > 0) {
      res.push(i + 1);
    }
  }

  return res;
}

var input = [4, 3, 2, 7, 8, 2, 3, 1];
var out = findDisappearedNumbers(input);

console.log(out);

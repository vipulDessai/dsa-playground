export const url = '[Jump Game](https://leetcode.com/problems/jump-game)';

function canJump(nums: number[]): boolean {
  const n = nums.length;

  let m = 0;
  for (let i = 0; i < n; ++i) {
    if (m < i) {
      return false;
    }

    m = Math.max(m, i + nums[i]);
  }

  return true;
}

var input = [2, 3, 1, 1, 4];
var out = canJump(input);

console.log(out);

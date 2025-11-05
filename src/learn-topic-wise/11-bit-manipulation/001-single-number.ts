export const url =
  '[Single Number](https://leetcode.com/problems/single-number/description/)';

function singleNumber(nums: number[]): number {
  let res = 0; // because n ^ 0 = n

  for (const n of nums) {
    // as XOR or any 2 number is 0,
    // all the numbers appearing twice will turn 0,
    // and the answer will remain in res
    res ^= n;
  }

  return res;
}

var input = [2, 2, 1];
var out = singleNumber(input);

console.log(out);

export const url =
  '[Third Maximum Number](https://leetcode.com/problems/third-maximum-number/)';

function thirdMax(nums: number[]): number {
  let first = -Infinity,
    second = -Infinity,
    third = -Infinity;

  for (let i = 0; i < nums.length; ++i) {
    const num = nums[i];

    if (num === first || num === second || num === third) {
      continue;
    }

    if (num > first) {
      third = second;
      second = first;
      first = num;
    } else if (num > second) {
      third = second;
      second = num;
    } else if (num > third) {
      third = num;
    }
  }

  return third === -Infinity ? first : third;
}

var input = [1, 2, 2, 2];
var out = thirdMax(input);

console.log(out);

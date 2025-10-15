export const url =
  '[Remove Element](https://leetcode.com/problems/remove-element/description/) ';

function removeElement(nums: number[], val: number): number {
  const n = nums.length;

  let k = 0;
  for (let i = 0; i < n; ++i) {
    if (nums[i] !== val) {
      nums[k] = nums[i];
      ++k;
    }
  }

  return k;
}

var input = [3, 2, 2, 3],
  t = 3;
var out = removeElement(input, t);

console.log(out);

export const url =
  '[valid triangle number](https://leetcode.com/problems/valid-triangle-number/)';

// 🧠 Triangle Validity Rule
// A triangle is valid only if the sum of any two sides
// is greater than the third
// if the array is sorted, you only need to check
// nums[i] + nums[j] > nums[k]
// This condition ensures that the three sides obey the triangle inequality.

function triangleNumber(nums: number[]): number {
  function search(start: number, t: number) {
    let l = start,
      r = n,
      res = r;

    while (l < r) {
      const m = Math.floor(l + (r - l) / 2);

      if (nums[m] >= t) {
        res = m;
        r = m;
      } else {
        l = m + 1;
      }
    }

    return res;
  }

  const n = nums.length;

  nums.sort((a, b) => a - b);

  let res = 0;
  for (let i = 0; i < n - 2; ++i) {
    if (nums[i] === 0) continue;

    for (let j = i + 1; j < n - 1; ++j) {
      const t = nums[i] + nums[j];
      const k = search(j + 1, t);

      // since the ask is find all sides that form trangle
      // i.e. nums[i] + nums[j] < nums[k]
      // k is a cutoff point where nums[i] + nums[j] < nums[k]
      // i.e. k and anything above will be invalid triangle
      // i.e. from index j + 1 to k - 1 are valid indices
      // so to get the number of indices from J + 1 to k - 1
      // the formula is k - 1 - j
      res += k - 1 - j; // which simplifies to k - (j + 1) or IDK complicates to 🤣
    }
  }

  return res;
}

var input = [2, 2, 3, 4];
var out = triangleNumber(input);

console.log(out);

export const url =
  '[find target indices after sorting array](https://leetcode.com/problems/find-target-indices-after-sorting-array/)';

function targetIndices(nums: number[], target: number): number[] {
  const n = nums.length;
  nums.sort((a, b) => a - b);

  let low = (() => {
    let l = 0,
      r = n - 1,
      result = -1;
    while (l <= r) {
      const m = Math.floor(l + (r - l) / 2);

      if (nums[m] === target) {
        result = m;
        r = m - 1;
      } else if (nums[m] > target) {
        r = m - 1;
      } else {
        l = m + 1;
      }
    }

    return result;
  })();

  const high = (() => {
    let l = 0,
      r = n - 1,
      result = -1;
    while (l <= r) {
      const m = Math.floor(l + (r - l) / 2);

      if (nums[m] === target) {
        result = m;
        l = m + 1;
      } else if (nums[m] > target) {
        r = m - 1;
      } else {
        l = m + 1;
      }
    }

    return result;
  })();

  const res: number[] = [];

  if (low !== -1 || high !== -1) {
    while (low <= high) {
      res.push(low++);
    }
  }

  return res;
}

var input = [1, 2, 5, 2, 3],
  t = 3;
var out = targetIndices(input, t);

console.log(out);

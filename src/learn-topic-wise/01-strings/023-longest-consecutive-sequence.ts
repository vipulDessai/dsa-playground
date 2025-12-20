export const url =
  '[Longest Consecutive Sequence](https://leetcode.com/problems/longest-consecutive-sequence/description/)';

function longestConsecutive(nums: number[]) {
  const n = nums.length;
  const h = new Set<number>();
  for (let i = 0; i < n; ++i) {
    h.add(nums[i]);
  }

  let rMax = 0;
  for (let i = 0; i < n; ++i) {
    // if num - 1 is there that means we have
    // to start from num - 1
    if (!h.has(nums[i] - 1)) {
      let cur = nums[i] + 1;
      while (h.has(cur)) {
        cur += 1;
      }

      rMax = Math.max(rMax, cur - nums[i]);
    }
  }

  return rMax;
}

let intArr = [100, 4, 200, 1, 3, 2];
let r = longestConsecutive(intArr);
console.log(r);

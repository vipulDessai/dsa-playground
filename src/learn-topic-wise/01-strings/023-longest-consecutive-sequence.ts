export const url =
  '[Longest Consecutive Sequence](https://leetcode.com/problems/longest-consecutive-sequence/description/)';

function longestConsecutive(nums: number[]) {
  const n = nums.length;
  const h = new Set<number>();
  for (let i = 0; i < n; ++i) {
    h.add(nums[i]);
  }

  let rMax = 0;

  // important to iterate over hash set
  // coz there might be repeated numbers
  for (const num of h) {
    // if num - 1 is there that means we have
    // to start from num - 1 and so on,
    // i.e. start from the smallest number
    if (!h.has(num - 1)) {
      let cur = num,
        streak = 1;
      while (h.has(++cur)) {
        ++streak;
      }

      rMax = Math.max(rMax, streak);
    }
  }

  return rMax;
}

let intArr = [100, 4, 200, 1, 3, 2];
let r = longestConsecutive(intArr);
console.log(r);

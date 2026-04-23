export const url = "[Contiguous Array](https://leetcode.com/problems/contiguous-array)"

function findMaxLength(nums: number[]): number {
  const n = nums.length;
  const map = new Map();

  map.set(0, -1);

  let c = 0,
    pSum = 0;
  for (let i = 0; i < n; ++i) {
    pSum += nums[i] == 1 ? 1 : -1;

    if (map.has(pSum)) {
      c = Math.max(c, i - map.get(pSum));
    } else {
      map.set(pSum, i);
    }
  }

  return c;
}

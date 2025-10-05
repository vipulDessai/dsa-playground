export const url =
  '[Rearrange Array Elements by Sign](https://leetcode.com/problems/rearrange-array-elements-by-sign/description/)';

// this is little difficult and slow, but this was my personal intuition
function rearrangeArray_find_pair(nums: number[]): number[] {
  const n = nums.length;
  let l = 0,
    r = 1;

  const res: number[] = [];
  while (r < n && l < n) {
    if (nums[l] > 0 && nums[r] < 0) {
      res.push(nums[l]);
      res.push(nums[r]);

      ++l;
      while (nums[l] < 0 && l < n) {
        ++l;
      }
    } else if (nums[l] < 0 && nums[r] > 0) {
      res.push(nums[r]);
      res.push(nums[l]);

      ++l;
      while (nums[l] > 0 && l < n) {
        ++l;
      }
    }

    ++r;
  }

  return res;
}

var input = [3, 1, -2, -5, 2, -4];
var out = rearrangeArray_find_pair(input);

console.log(out);

// this is simpler
// based on the intuition that, the pair index is always known
// i.e.
// positive index starts from 0 and is incremented +2
// & negetive index starts from 1 and is incremented +2
function rearrangeArray_by_index(nums: number[]): number[] {
  const n = nums.length;
  let l = 0,
    r = 1;
  const res = Array(n).fill(0);

  for (let i = 0; i < n; ++i) {
    const cur = nums[i];
    if (cur > 0) {
      res[l] = cur;
      l += 2;
    } else {
      res[r] = cur;
      r += 2;
    }
  }

  return res;
}

var input = [3, 1, -2, -5, 2, -4];
var out = rearrangeArray_by_index(input);

console.log(out);

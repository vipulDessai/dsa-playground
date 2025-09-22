export const url =
  '[Intersection of Two Arrays](https://leetcode.com/problems/intersection-of-two-arrays/description/)';

function intersection(nums1: number[], nums2: number[]): number[] {
  nums1.sort((a, b) => a - b);
  nums2.sort((a, b) => a - b);

  let i = 0,
    j = 0,
    res = new Set<number>();

  while (i < nums1.length && j < nums2.length) {
    if (nums1[i] === nums2[j]) {
      res.add(nums1[i]);
      ++i;
      ++j;
    } else {
      if (nums1[i] < nums2[j]) {
        ++i;
      } else {
        ++j;
      }
    }
  }

  return Array.from(res);
}

var i1 = [4, 9, 5],
  i2 = [9, 4, 9, 8, 4];
var out = intersection(i1, i2);

console.log(out);

export const url =
  '[Intersection of Two Arrays II](https://leetcode.com/problems/intersection-of-two-arrays-ii/description/)';

function intersect(nums1: number[], nums2: number[]): number[] {
  nums1.sort((a, b) => a - b);
  nums2.sort((a, b) => a - b);

  const res: number[] = [];
  let i = 0,
    j = 0;
  while (i < nums1.length && j < nums2.length) {
    if (nums1[i] === nums2[j]) {
      res.push(nums1[i]);
      ++i;
      ++j;
    } else {
      if (nums1[i] >= nums2[j]) {
        ++j;
      } else {
        ++i;
      }
    }
  }

  return res;
}

var i1 = [4, 9, 5],
  i2 = [9, 4, 9, 8, 4];
var out = intersect(i1, i2);

console.log(out);

export const url =
  '[Merge Sorted Array](https://leetcode.com/problems/merge-sorted-array/)';

// my solution
function merge_with_extra_space(
  nums1: number[],
  m: number,
  nums2: number[],
  n: number,
): void {
  const res = Array(m + n).fill(0);

  let l = 0,
    r = 0,
    i = 0;
  while (i < m + n) {
    if (r < n) {
      if (nums1[l] !== 0 && nums1[l] <= nums2[r]) {
        res[i] = nums1[l];
        ++l;
      } else {
        res[i] = nums2[r];
        ++r;
      }
    } else {
      res[i] = nums1[l];
      ++l;
    }

    ++i;
  }

  nums1 = res;
}

var i1 = [1, 2, 3, 0, 0, 0],
  i2 = [2, 5, 6],
  m = 3,
  n = 3;

merge_with_extra_space(i1, m, i2, n);

function merge_array_manipulation(
  nums1: number[],
  m: number,
  nums2: number[],
  n: number,
): void {
  let i = m - 1; // Pointer for nums1's valid elements
  let j = n - 1; // Pointer for nums2
  let k = m + n - 1; // Pointer for placement in nums1

  // Merge from the back
  while (i >= 0 && j >= 0) {
    if (nums1[i] > nums2[j]) {
      nums1[k] = nums1[i];
      i--;
    } else {
      nums1[k] = nums2[j];
      j--;
    }
    k--;
  }

  // If nums2 has remaining elements
  while (j >= 0) {
    nums1[k] = nums2[j];
    j--;
    k--;
  }
}

var i1 = [0],
  i2 = [1],
  m = 0,
  n = 1;
merge_array_manipulation(i1, m, i2, n);

console.log('foo');

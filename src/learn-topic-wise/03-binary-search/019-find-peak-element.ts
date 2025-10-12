export const url =
  '[find peak element](https://leetcode.com/problems/find-peak-element/)';

// Binary search doesn’t compare all peaks — it follows local slope.
// So depending on the initial mid,
// it may land on a smaller peak even if a stronger one exists elsewhere.
function findPeakElement(nums: number[]): number {
  let l = 0,
    r = nums.length - 1;

  while (l < r) {
    const m = Math.floor(l + (r - l) / 2);

    if (nums[m] > nums[m + 1]) {
      r = m;
    } else {
      l = m + 1;
    }
  }

  return l;
}

var input = [1, 6, 1, 10, 1];
var out = findPeakElement(input);

console.log(out);

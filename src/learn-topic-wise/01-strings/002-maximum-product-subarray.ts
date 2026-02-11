export const url =
  '[Maximum Product Subarray](https://leetcode.com/problems/maximum-product-subarray/description/)';

function maxProduct(nums: number[]): number {
  let max = Math.max(...nums),
    curMax = 1,
    curMin = 1;

  for (const n of nums) {
    const t = curMax * n;
    // ^ dont put this in the Math.min or max
    // coz curMax is used in curMin

    curMax = Math.max(t, curMin * n, n);
    curMin = Math.min(t, curMin * n, n);

    // compare max with every iteration and not
    // at the end
    max = Math.max(max, curMax);
  }

  return max;
}

var input = [2, -5, -2, -4, 3];
var input = [2, 3, -2, 4];
var input = [0, 1, 1, 5, -6];
console.log(maxProduct(input));

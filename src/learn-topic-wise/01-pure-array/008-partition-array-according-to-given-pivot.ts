export const url =
  '[Partition Array According to Given Pivot](https://leetcode.com/problems/partition-array-according-to-given-pivot/description/)';

function pivotArray(nums: number[], pivot: number): number[] {
    const n = nums.length, res: number[] = [];

    for(let i = 0; i < n; ++i) {
        if(nums[i] < pivot) {
            res.push(nums[i]);
        }
    }

    for(let i = 0; i < n; ++i) {
        if(nums[i] === pivot) {
            res.push(nums[i]);
        }
    }

    for(let i = 0; i < n; ++i) {
        if(nums[i] > pivot) {
            res.push(nums[i]);
        }
    }

    return res;
};

var input = [],
  p = 0;
var out = pivotArray(input, p);

console.log(out);

export const url = 'https://leetcode.com/problems/array-partition/description/';

function arrayPairSum(nums: number[]): number {
    const n = nums.length;

    nums.sort((a, b) => a - b);

    let res = 0;
    for (let i = 0; i < n; i += 2) {
        res += nums[i];
    }

    return res;
}

var input = [];
var out = arrayPairSum(input);

console.log(out);

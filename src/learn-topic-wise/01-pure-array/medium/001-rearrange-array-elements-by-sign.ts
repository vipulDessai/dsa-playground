export const url =
    '[Rearrange Array Elements by Sign](https://leetcode.com/problems/rearrange-array-elements-by-sign/description/)';

function rearrangeArray(nums: number[]): number[] {
    const n = nums.length;

    const res = Array(n).fill(0);
    let pI = 0,
        nI = 1;
    for (const num of nums) {
        if (num > 0) {
            res[pI] = num;
            pI += 2;
        } else {
            res[nI] = num;
            nI += 2;
        }
    }

    return res;
}

var input = [];
console.log(rearrangeArray(input));

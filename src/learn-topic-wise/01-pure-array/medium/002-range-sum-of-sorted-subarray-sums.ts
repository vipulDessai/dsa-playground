export const url =
    '[Range Sum of Sorted Subarray Sums](https://leetcode.com/problems/range-sum-of-sorted-subarray-sums/description)';

function rangeSum(
    nums: number[],
    n: number,
    left: number,
    right: number,
): number {
    const pSum: number[] = [];

    for (let i = 0; i < n; ++i) {
        let curSum = 0;
        for (let j = i; j < n; ++j) {
            curSum += nums[j];
            pSum.push(curSum);
        }
    }

    pSum.sort((a, b) => a - b);

    let res = 0;
    const MOD = 1e9 + 7;
    for (let i = left - 1; i < right; ++i) {
        res = (res + pSum[i]) % MOD;
    }

    return res;
}

var nums = [1, 2, 3, 4],
    n = 4,
    l = 1,
    r = 5;
console.log(rangeSum(nums, n, l, r));

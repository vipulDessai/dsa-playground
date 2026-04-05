export const url =
    '[Smallest Missing Integer Greater Than Sequential Prefix Sum](https://leetcode.com/problems/smallest-missing-integer-greater-than-sequential-prefix-sum/description/)';

function missingInteger(nums: number[]): number {
    let pSum = nums[0];
    for (let i = 1; i < nums.length; ++i) {
        if (nums[i] - 1 === nums[i - 1]) {
            pSum += nums[i];
        } else {
            break; // ask is stop immediately if sequence break starting from first element
        }
    }

    const s = new Set(nums);

    while (s.has(pSum)) {
        ++pSum;
    }

    return pSum;
}

var input = [1, 2, 3, 2, 5];
console.log(missingInteger(input));

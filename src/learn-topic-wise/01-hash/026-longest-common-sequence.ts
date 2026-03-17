export const url =
    '[Longest Consecutive Sequence](https://leetcode.com/problems/longest-consecutive-sequence/)';

function longestConsecutive(nums: number[]): number {
    const s = new Set(nums);

    let res = 0;

    // iterate over hash set, not the nums array, otherwise TLE, coz of repeats
    for (const num of s) {
        if (!s.has(num - 1)) {
            let cur = num + 1;
            while (s.has(cur)) {
                ++cur;
            }

            // cur - num gives the length or we can use
            // another variable for tracking length
            res = Math.max(res, cur - num);
        }
    }

    return res;
}

var input = [100, 4, 200, 1, 3, 2];
console.log(longestConsecutive(input));

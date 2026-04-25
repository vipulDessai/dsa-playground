export const url =
    '[Maximum Sum of Distinct Subarrays With Length K](https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/)';

function maximumSubarraySum(nums: number[], k: number): number {
    const n = nums.length;
    const freq = new Map<number, number>();

    let m = 0,
        sum = 0,
        i = 0,
        j = 0;
    while (j < k) {
        const cur = nums[j];
        freq.set(cur, (freq.get(cur) || 0) + 1);
        sum += cur;

        ++j;
    }

    while (j < n) {
        if (freq.size === k) {
            m = Math.max(m, sum);
        }

        sum -= nums[i];
        freq.set(nums[i], freq.get(nums[i])! - 1);

        // if the keys with value 0 is kept
        // then `freq.size === k` check will fail
        if (freq.get(nums[i]) === 0) {
            freq.delete(nums[i]);
        }

        ++i;

        sum += nums[j];
        freq.set(nums[j], (freq.get(nums[j]) || 0) + 1);
        ++j;
    }

    if (freq.size === k) {
        m = Math.max(m, sum);
    }

    return m;
}

var input = [1, 5, 4, 2, 9, 9, 9],
    k = 3;
console.log(maximumSubarraySum(input, k));

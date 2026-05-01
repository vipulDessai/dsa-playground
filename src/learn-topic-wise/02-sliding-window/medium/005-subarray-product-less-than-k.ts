export const url =
    '[subarray product less than k](https://leetcode.com/problems/subarray-product-less-than-k/)';

function numSubarrayProductLessThanK(nums: number[], k: number): number {
    if (k == 0) return 0;

    const n = nums.length;

    let l = 0,
        r = 0,
        c = 0,
        p = 1;
    while (r < n) {
        p *= nums[r];

        while (p >= k) {
            p /= nums[l];
            ++l;
        }

        c += r - l + 1;

        ++r;
    }

    return c;
}

var nums = [10, 5, 2, 6],
    k = 100;
console.log(numSubarrayProductLessThanK(nums, k));

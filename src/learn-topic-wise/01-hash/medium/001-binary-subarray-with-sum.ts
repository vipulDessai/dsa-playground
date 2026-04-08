export const url =
    '[Binary Subarrays With Sum](https://leetcode.com/problems/binary-subarrays-with-sum/description/)';

function numSubarraysWithSum(nums: number[], goal: number): number {
    const pMap = new Map<number, number>();
    pMap.set(0, 1);

    let pSum = 0,
        c = 0;
    for (const num of nums) {
        pSum += num;

        const cur = pMap.get(pSum - goal);
        if (typeof cur === 'number') {
            c += cur;
        }

        pMap.set(pSum, (pMap.get(pSum) || 0) + 1);
    }

    return c;
}

var nums = [1, 0, 1, 0, 1],
    g = 0;
console.log(numSubarraysWithSum(nums, g));

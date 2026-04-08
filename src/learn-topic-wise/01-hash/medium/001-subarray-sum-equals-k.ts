export const url =
    '[Subarray Sum Equals K](https://leetcode.com/problems/subarray-sum-equals-k/)';

function subarraySum(nums: number[], k: number): number {
    const pMap = new Map<number, number>();

    pMap.set(0, 1);

    let prefixSum = 0,
        count = 0;

    for (const num of nums) {
        prefixSum += num;

        const cur = pMap.get(prefixSum - k);
        if (typeof cur === 'number') {
            count += cur;
        }

        // here we want the count of all the subarray
        // that's why we are storing the count of occurence of
        // the current prefix sum
        pMap.set(prefixSum, (pMap.get(prefixSum) || 0) + 1);
    }

    return count;
}

var nums = [1, 2, 3, -2, -1, -4, 1, 1, 2],
    k = 3;
// var nums = [1, 1, 1],
//   k = 2;
var o = subarraySum(nums, k);

console.log(o);

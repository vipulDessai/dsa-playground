export const url =
    '[Find All Duplicates in an Array](https://leetcode.com/problems/find-all-duplicates-in-an-array/)';

function findDuplicates(nums: number[]): number[] {
    const result: number[] = [];

    for (const num of nums) {
        const index = Math.abs(num) - 1;
        if (nums[index] < 0) {
            result.push(Math.abs(num));
        } else {
            nums[index] = -nums[index];
        }
    }

    return result;
}

var input = [4, 3, 2, 7, 8, 2, 3, 1];
console.log(findDuplicates(input));

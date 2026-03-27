export const url =
    '[Sort Array by Increasing Frequency](https://leetcode.com/problems/sort-array-by-increasing-frequency/)';

function frequencySort(nums: number[]): number[] {
    const f = new Map<number, number>();

    for (let i = 0; i < nums.length; ++i) {
        f.set(nums[i], (f.get(nums[i]) || 0) + 1);
    }

    const fArr = [...f.entries()].sort((a, b) => {
        if (a[1] === b[1]) {
            // sort decreasing
            return b[0] - a[0];
        } else {
            // sort increasing
            return a[1] - b[1];
        }
    });

    const res: number[] = [];
    for (let i = 0; i < fArr.length; ++i) {
        let [k, v] = fArr[i];
        while (v > 0) {
            res.push(k);
            --v;
        }
    }
    return res;
}

var input = [2, 3, 1, 3, 2];
console.log(frequencySort(input));

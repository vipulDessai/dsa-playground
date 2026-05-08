export const url =
    '[Degree of an Array](https://leetcode.com/problems/degree-of-an-array/)';

function findShortestSubArray_w_maps(nums: number[]): number {
    // why we need multiple maps?
    // coz there could be multiple items with same degree
    // for them we need to compute the smallest length
    // refer findShortestSubArray_wo_maps for finding smallest length without maps
    const countMap = new Map<number, number>();
    const firstIndexMap = new Map<number, number>();
    const lastIndexMap = new Map<number, number>();

    for (let i = 0; i < nums.length; i++) {
        const num = nums[i];
        if (!firstIndexMap.has(num)) {
            firstIndexMap.set(num, i);
        }
        lastIndexMap.set(num, i);
        countMap.set(num, (countMap.get(num) || 0) + 1);
    }

    const degree = Math.max(...countMap.values());
    let minLength = nums.length;

    for (const [num, freq] of countMap.entries()) {
        if (freq === degree) {
            const length = lastIndexMap.get(num)! - firstIndexMap.get(num)! + 1;
            minLength = Math.min(minLength, length);
        }
    }

    return minLength;
}

function findShortestSubArray_wo_maps(nums: number[]): number {
    const n = nums.length;

    const freq = new Map<number, number>();
    for (let i = 0; i < n; ++i) {
        const cur = nums[i];
        freq.set(cur, (freq.get(cur) || 0) + 1);
    }

    let maxDeg = Math.max(...freq.values()),
        res = n;
    for (const [num, count] of freq.entries()) {
        if (count === maxDeg) {
            let start = -1,
                end = n - 1;
            for (let i = 0; i < n; ++i) {
                const cur = nums[i];
                if (start === -1 && cur === num) {
                    start = i;
                } else if (cur === num) {
                    end = i;
                }
            }
            res = Math.min(res, end - start + 1);
        }
    }

    return res;
}

var input = [1, 2, 2, 3, 1, 4, 2];
var input = [1, 2, 2, 3, 1];
var input = [1, 2, 2, 1, 2, 1, 1, 1, 1, 2, 2, 2];
var out = findShortestSubArray_wo_maps(input);

console.log(out);

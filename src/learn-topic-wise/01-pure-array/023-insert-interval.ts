export const url =
    '[Insert Interval](https://leetcode.com/problems/insert-interval/description/)';

function insert(intervals: number[][], newInterval: number[]): number[][] {
    const n = intervals.length,
        res: number[][] = [];

    let i = 0;

    // Iterate through intervals and add non-overlapping intervals before newInterval
    while (i < n && intervals[i][1] < newInterval[0]) {
        res.push(intervals[i]);
        ++i;
    }

    // Merge overlapping intervals
    let [min, max] = newInterval;
    while (i < n && intervals[i][1] >= min && intervals[i][0] <= max) {
        min = Math.min(min, intervals[i][0]);
        max = Math.max(max, intervals[i][1]);
        ++i;
    }
    res.push([min, max]);

    // Add non-overlapping intervals after newInterval
    while (i < n) {
        res.push(intervals[i]);
        ++i;
    }

    return res;
}

var input = [
        [1, 2],
        [3, 5],
        [6, 7],
        [8, 10],
        [12, 16],
    ],
    newIntervals = [2, 8];
console.log(insert(input, newIntervals));

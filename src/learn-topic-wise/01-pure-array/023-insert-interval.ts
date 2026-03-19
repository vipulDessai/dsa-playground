export const url =
    '[Insert Interval](https://leetcode.com/problems/insert-interval/description/)';

function insert(intervals: number[][], newInterval: number[]): number[][] {
    const result: number[][] = [];

    // Iterate through intervals and add non-overlapping intervals before newInterval
    let i = 0;
    while (i < intervals.length && intervals[i][1] < newInterval[0]) {
        result.push(intervals[i]);
        i++;
    }

    // Merge overlapping intervals
    while (i < intervals.length && intervals[i][0] <= newInterval[1]) {
        newInterval[0] = Math.min(newInterval[0], intervals[i][0]);
        newInterval[1] = Math.max(newInterval[1], intervals[i][1]);
        i++;
    }

    // Add merged newInterval
    result.push(newInterval);

    // Add non-overlapping intervals after newInterval
    while (i < intervals.length) {
        result.push(intervals[i]);
        i++;
    }

    return result;
}

var input = [
        [1, 3],
        [6, 9],
    ],
    newIntervals = [2, 5];
console.log(insert(input, newIntervals));

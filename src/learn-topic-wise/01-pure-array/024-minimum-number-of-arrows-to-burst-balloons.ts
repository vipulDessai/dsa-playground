export const url =
    '[Minimum Number of Arrows to Burst Balloons](https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/)';

function findMinArrowShots(points: number[][]): number {
    const n = points.length;

    if (n == 1) return 1;

    points.sort((a, b) => a[1] - b[1]);

    let res = 1,
        i = 0,
        p = points[0][1];
    while (i < n) {
        if (p < points[i][0]) {
            ++res;
            p = points[i][1];
        }

        ++i;
    }

    return res;
}

var input = [
    [10, 16],
    [2, 8],
    [1, 6],
    [7, 12],
];
console.log(findMinArrowShots(input));

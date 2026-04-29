// https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons/

function findMinArrowShots(points: number[][]): number {
    if (points.length === 0) return 0;

    let arrow = 1;

    points = points.sort((a, b) => a[1] - b[1]);
    let pos = points[0][1];

    for (let i = 0; i < points.length; i++) {
        if (pos < points[i][0]) {
            arrow++;
            pos = points[i][1];
        }
    }

    return arrow;
}

console.log(
    findMinArrowShots([
        [10, 16],
        [2, 8],
        [1, 6],
        [7, 12],
    ]),
);

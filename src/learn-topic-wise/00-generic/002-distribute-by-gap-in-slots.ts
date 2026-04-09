function distributeBallsInSlotsByGap(
    bucketPositions: number[],
    numBalls: number,
    gap: number,
) {
    let prevPos = bucketPositions[0];
    let ballsPlaced = 1;

    for (let i = 1; i < bucketPositions.length && ballsPlaced < numBalls; ++i) {
        const curPos = bucketPositions[i];

        if (curPos - prevPos >= gap) {
            prevPos = curPos;
            ++ballsPlaced;
        }
    }

    return ballsPlaced === numBalls;
}

console.log(distributeBallsInSlotsByGap([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 5, 3));

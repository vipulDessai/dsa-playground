export const url =
    '[Magnetic Force Between Two Balls](https://leetcode.com/problems/magnetic-force-between-two-balls/description/)';

function maxDistance_brute(position: number[], m: number): number {
    position = position.sort((a, b) => a - b);

    let minForce = 1;
    let maxForce = position[position.length - 1];

    let output = 1;
    for (let i = minForce; i < maxForce; ++i) {
        if (feasible(position, m, i)) {
            output = i;
        } else {
            break;
        }
    }

    return output;
}

// console.log(maxDistance_brute([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 5));

function feasible(position: number[], m: number, forceGap: number) {
    // Place the first ball at the first position.
    let prevBallPos = position[0];
    let ballsPlaced = 1;

    // Iterate on each 'position' and place a ball there if we can place it.
    for (let i = 1; i < position.length && ballsPlaced < m; ++i) {
        const currPos = position[i];
        // Check if we can place the ball at the current position.
        if (currPos - prevBallPos >= forceGap) {
            ballsPlaced += 1;
            prevBallPos = currPos;
        }
    }
    // If all 'm' balls are placed, return 'true'.
    return ballsPlaced == m;
}

function maxDistance_binarySearch(position: number[], m: number): number {
    position = position.sort((a, b) => a - b);

    let l = 1;
    const maxPosition = position[position.length - 1];
    let r = Math.ceil(maxPosition / (m - 1));

    while (l < r) {
        const mid = Math.floor(l + (r - l) / 2);
        if (feasible(position, m, mid)) {
            l = mid + 1;
        } else {
            r = m;
        }
    }

    return l - 1;
}

// console.log(maxDistance_binarySearch([1, 2, 3, 4, 5, 100], 3));
console.log(maxDistance_binarySearch([1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 5));

export const moduleHack = '';

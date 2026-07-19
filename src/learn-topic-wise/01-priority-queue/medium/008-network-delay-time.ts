export const url =
    '[Network Delay Time](https://leetcode.com/problems/network-delay-time/description/)';

import { dijkstra } from './007-dijkstra-algorithm';

function networkDelayTime(times: number[][], n: number, k: number): number {
    // since the times array is 1 indexed
    for (let i = 0; i < times.length; i++) {
        times[i] = [times[i][0] - 1, times[i][1] - 1, times[i][2]];
    }

    // represent node number as 0 indexed instead of 1 indexed
    const out = dijkstra(n, times, k - 1);

    let max = 0;
    for (let i = 0; i < out.length; i++) {
        // if any nodes arent reachable, return -1
        if (out[i] === Infinity) return -1;

        if (out[i] > max) {
            max = out[i];
        }
    }

    return max;
}

console.log(
    networkDelayTime(
        [
            [2, 1, 1],
            [2, 3, 1],
            [3, 4, 1],
        ],
        4,
        2,
    ),
);

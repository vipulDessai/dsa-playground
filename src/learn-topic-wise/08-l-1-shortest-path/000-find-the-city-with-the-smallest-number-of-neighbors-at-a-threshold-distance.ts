export const url =
    '[Find the City With the Smallest Number of Neighbors at a Threshold Distance](https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/description/)';

function findTheCity(
    n: number,
    edges: number[][],
    distanceThreshold: number,
): number {
    const dist = Array.from({ length: n }, () => Array(n).fill(Infinity));

    for (let i = 0; i < n; ++i) {
        dist[i][i] = 0;
    }

    for (const [f, t, w] of edges) {
        dist[f][t] = w;
        dist[t][f] = w;
    }

    for (let k = 0; k < n; ++k) {
        for (let i = 0; i < n; ++i) {
            for (let j = 0; j < n; ++j) {
                if (dist[i][k] < Infinity && dist[k][j] < Infinity) {
                    dist[i][j] = Math.min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }
    }

    let city = 0,
        rC = n;
    for (let i = 0; i < n; ++i) {
        let c = 0;
        for (let j = 0; j < n; ++j) {
            if (i !== j && dist[i][j] <= distanceThreshold) {
                ++c;
            }
        }

        if (c <= rC) {
            city = i;
            rC = c;
        }
    }

    return city;
}

var n = 4,
    e = [
        [0, 1, 3],
        [1, 2, 1],
        [1, 3, 4],
        [2, 3, 1],
    ],
    d = 4;
console.log(findTheCity(n, e, d));

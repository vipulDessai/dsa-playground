export const url =
    '[Minimum Cost to Convert String I](https://leetcode.com/problems/minimum-cost-to-convert-string-i/)';

function minimumCost(
    source: string,
    target: string,
    original: string[],
    changed: string[],
    cost: number[],
): number {
    const INF = Number.MAX_SAFE_INTEGER;
    const n = 26; // lowercase letters a-z
    const dist: number[][] = Array.from({ length: n }, () =>
        Array(n).fill(INF),
    );

    // Initialize distances
    for (let i = 0; i < n; i++) {
        dist[i][i] = 0;
    }

    // Add edges
    for (let i = 0; i < original.length; i++) {
        const u = original[i].charCodeAt(0) - 97,
            v = changed[i].charCodeAt(0) - 97;
        dist[u][v] = Math.min(dist[u][v], cost[i]);
    }

    // Floyd–Warshall for all-pairs shortest paths
    for (let k = 0; k < n; k++) {
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                if (dist[i][k] < INF && dist[k][j] < INF) {
                    dist[i][j] = Math.min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }
    }

    // Compute total conversion cost
    let total = 0;
    for (let i = 0; i < source.length; i++) {
        const u = source.charCodeAt(i) - 97,
            v = target.charCodeAt(i) - 97;
        if (dist[u][v] === INF) {
            return -1; // impossible conversion
        }
        total += dist[u][v];
    }

    return total;
}

var s = 'abcd',
    t = 'acbe',
    o = ['a', 'b', 'c', 'c', 'e', 'd'],
    c = ['b', 'c', 'b', 'e', 'b', 'e'],
    cost = [2, 5, 5, 1, 2, 20];
console.log(minimumCost(s, t, o, c, cost));

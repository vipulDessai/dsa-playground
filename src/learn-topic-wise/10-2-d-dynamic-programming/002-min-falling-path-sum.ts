export const url =
    '[Minimum Falling Path Sum](https://leetcode.com/problems/minimum-falling-path-sum/description/)';

function minFallingPathSum(matrix: number[][]): number {
    const rLen = matrix.length,
        cLen = matrix[0].length;

    const d = [-1, 0, 1];
    const dp = Array.from({ length: rLen }, () => Array(cLen).fill(Infinity));
    function dfs(r: number, c: number) {
        if (c === cLen || c < 0) {
            return Infinity;
        }
        if (r === rLen - 1) {
            return matrix[r][c];
        }

        if (dp[r][c] !== Infinity) {
            return dp[r][c];
        }

        let m = Infinity;
        for (let j = 0; j < 3; ++j) {
            const cur = dfs(r + 1, c + d[j]);
            m = Math.min(m, matrix[r][c] + cur);
        }

        dp[r][c] = m;
        return m;
    }

    let min = Infinity;
    for (let i = 0; i < cLen; ++i) {
        min = Math.min(min, dfs(0, i));
    }

    return min;
}

var input = [
    [2, 1, 3],
    [6, 5, 4],
    [7, 8, 9],
];
console.log(minFallingPathSum(input));

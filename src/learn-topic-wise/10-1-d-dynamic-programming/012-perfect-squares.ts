export const url =
  '[Perfect Squares](https://leetcode.com/problems/perfect-squares/)';

function numSquares_topDown(n: number): number {
  const dp = new Map<number, number>();

  function dfs(k: number) {
    if (k === 0) return 0;
    if (dp.has(k)) return dp.get(k)!;

    let m = Infinity;
    for (let i = 1; i * i <= k; ++i) {
      m = Math.min(m, 1 + dfs(k - i * i));
    }

    dp.set(k, m);
    return m;
  }

  return dfs(n);
}

var input = 12;
console.log(numSquares_topDown(input));

function numSquares_BottomUp(n: number): number {
  const dp = new Array(n + 1).fill(Infinity);
  dp[0] = 0;

  for (let i = 1; i <= n; i++) {
    for (let j = 1; j * j <= i; j++) {
      dp[i] = Math.min(dp[i], dp[i - j * j] + 1);
    }
  }

  return dp[n];
}

var input = 12;
console.log(numSquares_BottomUp(input));

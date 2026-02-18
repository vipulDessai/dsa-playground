export const url = '[Coin Change](https://leetcode.com/problems/coin-change/)';

function coinChange_topDown(coins: number[], amount: number): number {
  const memo: Map<number, number> = new Map();

  function dfs(rem: number): number {
    // Base cases
    if (rem === 0) return 0;
    if (rem < 0) return Infinity;

    // Check memo
    if (memo.has(rem)) return memo.get(rem)!;

    let minCoins = Infinity;

    for (const coin of coins) {
      const res = dfs(rem - coin);
      if (res !== Infinity) {
        minCoins = Math.min(minCoins, 1 + res);
      }
    }

    memo.set(rem, minCoins);
    return minCoins;
  }

  const ans = dfs(amount);
  return ans === Infinity ? -1 : ans;
}

var input = [1, 2, 5],
  a = 11;
console.log(coinChange_topDown(input, a));

function coinChange_bottomUp(coins: number[], amount: number): number {
  const dp = Array(amount + 1).fill(Infinity);
  dp[0] = 0;

  for (let i = 1; i <= amount; ++i) {
    for (const c of coins) {
      if (i - c >= 0) {
        dp[i] = Math.min(dp[i], dp[i - c] + 1);
      }
    }
  }

  return dp[amount] === Infinity ? -1 : dp[amount];
}

var input = [1, 2, 5],
  a = 11;
console.log(coinChange_bottomUp(input, a));

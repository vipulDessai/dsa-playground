export const url = '[Coin Change](https://leetcode.com/problems/coin-change/)';

function coinChange(coins: number[], amount: number): number {
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
console.log(coinChange(input, a));

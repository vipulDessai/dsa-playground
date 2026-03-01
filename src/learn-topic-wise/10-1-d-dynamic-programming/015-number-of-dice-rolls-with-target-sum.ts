export const url =
  '[Number of Dice Rolls With Target Sum](https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/description/)';

function numRollsToTarget_dp_topDown(
  n: number,
  k: number,
  target: number,
): number {
  const MOD = 1e9 + 7,
    mem = new Map<string, number>();

  function dfs(d: number, t: number) {
    if (d === 0 && t === 0) return 1;
    if (d === 0 || t < 0) return 0;

    const i = `${d},${t}`;
    if (mem.has(i)) return mem.get(i)!;

    let w = 0;
    for (let j = 1; j <= k; ++j) {
      w = (w + dfs(d - 1, t - j)) % MOD;
    }

    mem.set(i, w);
    return w;
  }

  return dfs(n, target);
}

var n = 3,
  k = 6,
  t = 10;
console.log(numRollsToTarget_dp_topDown(n, k, t));

export const url = '[Decode Ways](https://leetcode.com/problems/decode-ways/)';

function numDecodings_topDown(s: string): number {
  const memo: Map<number, number> = new Map();

  function dfs(i: number): number {
    // Base case: reached end → valid decoding
    if (i === s.length) return 1;

    // Leading zero → invalid
    if (s[i] === '0') return 0;

    // Already computed
    if (memo.has(i)) return memo.get(i)!;

    // Option 1: take one digit
    let ways = dfs(i + 1);

    // Option 2: take two digits if valid
    if (i + 1 < s.length) {
      const twoDigit = parseInt(s.substring(i, i + 2));
      if (twoDigit >= 10 && twoDigit <= 26) {
        ways += dfs(i + 2);
      }
    }

    memo.set(i, ways);
    return ways;
  }

  return dfs(0);
}

var input = '10611';
console.log(numDecodings_topDown(input));

function numDecodings_bottomUp(s: string): number {
  const n = s.length;
  if (n === 0 || s[0] === '0') return 0;

  const dp: number[] = new Array(n + 1).fill(0);
  dp[0] = 1; // base case: empty string
  dp[1] = 1; // as s[0] !== '0'

  for (let i = 2; i <= n; i++) {
    // Single digit
    if (s[i - 1] !== '0') {
      dp[i] = dp[i - 1];
    }

    // Two digits
    const twoDigit = parseInt(s.substring(i - 2, i));
    if (twoDigit >= 10 && twoDigit <= 26) {
      dp[i] += dp[i - 2];
    }
  }

  return dp[n];
}

var input = '10611';
console.log(numDecodings_bottomUp(input));

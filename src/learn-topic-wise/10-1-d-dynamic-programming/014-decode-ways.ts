export const url = '[Decode Ways](https://leetcode.com/problems/decode-ways/)';

function numDecodings(s: string): number {
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

var input = '';
console.log(numDecodings(input));

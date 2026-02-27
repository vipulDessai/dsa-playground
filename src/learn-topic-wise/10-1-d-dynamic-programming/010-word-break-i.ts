export const url = '[Word Break](https://leetcode.com/problems/word-break/)';

function wordBreak_top_down(s: string, wordDict: string[]): boolean {
  const dp = new Map<number, boolean>(),
    wSet = new Set(wordDict);

  function dfs(i: number) {
    if (i === s.length) return true;

    if (dp.has(i)) return dp.get(i)!;

    for (let j = i + 1; j <= s.length; ++j) {
      const str = s.substring(i, j);
      if (wSet.has(str) && dfs(j)) {
        dp.set(i, true);
        return true;
      }
    }

    return false;
  }

  return dfs(0);
}

var inputS = 'leetcode',
  wDict = ['leet', 'code'];
console.log(wordBreak_top_down(inputS, wDict));

export function wordBreak_bottom_up(s: string, wordDict: string[]): boolean {
  const dp = new Array(s.length + 1).fill(false);
  dp[0] = true;

  for (let i = 1; i <= s.length; i++) {
    for (let w of wordDict) {
      let start = i - w.length;
      if (start >= 0 && dp[start] && s.substring(start, i) === w) {
        dp[i] = true;
        break;
      }
    }
  }
  return dp[s.length];
}

// var inputS = 'leetcode',
//   wDict = ['leet', 'code'];
// console.log(wordBreak_bottom_up(inputS, wDict));

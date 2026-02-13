export const url = '[Word Break](https://leetcode.com/problems/word-break/)';

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

var inputS = 'leetcode',
  wDict = ['leet', 'code'];
console.log(wordBreak_bottom_up(inputS, wDict));

function wordBreak_top_down(s: string, wordDict: string[]): boolean {
  const wordSet = new Set(wordDict);
  const memo: Map<number, boolean> = new Map();

  function canBreak(start: number): boolean {
    // If we've reached the end, it's a valid segmentation
    if (start === s.length) return true;

    // If already computed, return cached result
    if (memo.has(start)) return memo.get(start)!;

    // Try every possible end index from start
    for (let end = start + 1; end <= s.length; end++) {
      const prefix = s.substring(start, end);
      if (wordSet.has(prefix) && canBreak(end)) {
        memo.set(start, true);
        return true;
      }
    }

    // No valid segmentation found
    memo.set(start, false);
    return false;
  }

  return canBreak(0);
}

var inputS = 'leetcode',
  wDict = ['leet', 'code'];
console.log(wordBreak_top_down(inputS, wDict));

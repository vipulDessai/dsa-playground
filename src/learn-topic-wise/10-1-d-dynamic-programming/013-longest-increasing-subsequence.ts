export const url =
  '[Longest Increasing Subsequence](https://leetcode.com/problems/longest-increasing-subsequence/description/)';

// TLE at 24/56
function lengthOfLIS_topDown(nums: number[]): number {
  const dp = new Map<string, number>();
  function dfs(p: number, c: number) {
    if (c === nums.length) {
      return 0;
    }

    const i = `${p},${c}`;
    if (dp.has(i)) return dp.get(i);

    // 1. skip current
    let mLen = dfs(p, c + 1);

    // check if prev is -1 or strictly increasing sequence
    if (p < 0 || nums[p] < nums[c]) {
      mLen = Math.max(mLen, 1 + dfs(c, c + 1));
    }

    dp.set(i, mLen);
    return mLen;
  }

  return dfs(-1, 0);
}

// var input = [10, 9, 2, 5, 3, 7, 101, 18];
// console.log(lengthOfLIS_topDown(input));

function lengthOfLIS_bottomUp(nums: number[]): number {
  const n = nums.length,
    dp = Array(n).fill(1);

  for (let i = 0; i < n; ++i) {
    for (let j = 0; j < i; ++j) {
      if (nums[j] < nums[i]) {
        dp[i] = Math.max(dp[i], 1 + dp[j]);
      }
    }
  }

  return Math.max(...dp);
}

var input = [10, 9, 2, 5, 3, 7, 101, 18];
console.log(lengthOfLIS_bottomUp(input));

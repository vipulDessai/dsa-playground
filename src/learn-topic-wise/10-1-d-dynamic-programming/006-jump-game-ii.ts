export const url = '[Jump Game II](https://leetcode.com/problems/jump-game-ii)';

// START - greedy algorithm is very difficult
function jump_greedy_difficult(nums: number[]): number {
  let jumps = 0,
    end = 0,
    max = 0;

  for (let i = 0; i < nums.length - 1; ++i) {
    max = Math.max(max, i + nums[i]);

    if (i === end) {
      jumps++;
      end = max;
    }
  }

  return jumps;
}

var input = [2, 3, 0, 1, 4];
console.log(jump_greedy_difficult(input));
// END - greedy algorithm is very difficult

function jump_dp_topDown(nums: number[]): number {
  const n = nums.length;

  const dp = Array(n).fill(Infinity);
  function dfs(i: number) {
    if (i >= n - 1) return 0;

    if (dp[i] !== Infinity) return dp[i];

    let m = Infinity;
    for (let j = 1; j <= nums[i]; ++j) {
      m = Math.min(m, 1 + dfs(i + j));
    }

    dp[i] = m;
    return m;
  }

  return dfs(0);
}

var input = [2, 3, 0, 1, 4];
console.log(jump_dp_topDown(input));

// TODO
function jump_dp_bottom_up(nums: number[]): number {
  const n = nums.length;
  const dp = new Array(n).fill(Infinity);
  dp[0] = 0;

  for (let i = 1; i < n; i++) {
    for (let j = 0; j < i; j++) {
      if (j + nums[j] >= i) {
        dp[i] = Math.min(dp[i], dp[j] + 1);
      }
    }
  }

  return dp[n - 1];
}

var input = [0, 0, 0];
console.log(jump_dp_bottom_up(input));

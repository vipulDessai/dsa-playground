export const url = '[Jump Game II](https://leetcode.com/problems/jump-game-ii)';

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

var input = [2, 3, 0, 1, 4];
console.log(jump_dp_bottom_up(input));

function jump_dp_top_down_memoise(nums: number[]): number {
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

var input = [2, 3, 0, 1, 4];
console.log(jump_dp_top_down_memoise(input));
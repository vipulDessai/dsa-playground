export const url =
  'https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/';

function maxProfit(prices: number[]): number {
  let l = 0,
    r = 1,
    maxP = 0;

  while (r <= prices.length - 1) {
    if (prices[l] < prices[r]) {
      maxP = Math.max(maxP, prices[r] - prices[l]);
    } else {
      l = r;
    }

    ++r;
  }

  return maxP;
}

console.log(maxProfit([1, 2]));

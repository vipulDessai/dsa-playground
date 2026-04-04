export const url =
    'https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/';

function maxProfit(prices: number[]): number {
    let min = Infinity;
    let res = 0;

    for (const p of prices) {
        if (p < min) {
            min = p;
        } else {
            res = Math.max(res, p - min);
        }
    }

    return res;
}

console.log(maxProfit([7, 1, 5, 3, 6, 4]));

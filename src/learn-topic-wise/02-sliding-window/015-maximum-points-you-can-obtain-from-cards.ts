export const url =
  '[Maximum Points You Can Obtain from Cards](https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/description/)';

function maxScore(cardPoints: number[], k: number): number {
  const n = cardPoints.length;
  let l = 0,
    r = 0,
    min = Infinity,
    sum = 0;

  const total = cardPoints.reduce((acc, cur) => acc + cur, 0);

  while (r < n - k) {
    sum += cardPoints[r];
    ++r;
  }
  --r;

  while (r < n) {
    min = Math.min(min, sum);

    sum -= cardPoints[l];
    ++l;
    ++r;
    sum += cardPoints[r];
  }

  return total - min;
}

var input = [1, 2, 3, 4, 5, 6, 1],
  k = 3;
var out = maxScore(input, k);

console.log(out);

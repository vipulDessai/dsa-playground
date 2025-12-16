export const url =
  '[Distribute Candies](https://leetcode.com/problems/distribute-candies/)';

function distributeCandies(candyType: number[]): number {
  const cSet = new Set(candyType);
  const n = candyType.length / 2;

  return Math.min(n, cSet.size);
}

var input = [];
var out = distributeCandies(input);

console.log(out);

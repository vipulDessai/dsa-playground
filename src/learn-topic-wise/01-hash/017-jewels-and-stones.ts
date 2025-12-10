export const url =
  '[Jewels and Stones](https://leetcode.com/problems/jewels-and-stones/)';

function numJewelsInStones(jewels: string, stones: string): number {
  const sSet = new Set<string>(jewels);

  let res = 0;
  for (let i = 0; i < stones.length; ++i) {
    const c = stones[i];

    if (sSet.has(c)) ++res;
  }

  return res;
}

var jewels = 'aA',
  stones = 'aAAbbbb';
var out = numJewelsInStones(jewels, stones);

console.log(out);

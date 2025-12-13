export const url =
  '[Number of Good Pairs](https://leetcode.com/problems/number-of-good-pairs/)';

function numIdenticalPairs(nums: number[]): number {
  const n = nums.length;
  const c = new Map<number, number[]>();

  for (let i = 0; i < n; ++i) {
    const cur = nums[i];

    if (c.has(cur)) {
      const v = c.get(cur)!;
      c.set(cur, [...v, i]);
    } else {
      c.set(cur, [i]);
    }
  }

  let res: [number, number][] = [];
  for (let i = 0; i < n; ++i) {
    const cur = nums[i];

    if (c.has(cur)) {
      const sameOccurence = c.get(cur)!;

      // remove the current one
      sameOccurence.shift();

      c.set(cur, [...sameOccurence]);

      for (const nextI of sameOccurence) {
        res.push([i, nextI]);
      }
    }
  }

  return res.length;
}

var input = [1, 2, 3, 1, 1, 3];
var out = numIdenticalPairs(input);

console.log(out);

function numIdenticalPairs_ai(nums: number[]): number {
  const freq: Map<number, number> = new Map();
  let result = 0;

  for (const num of nums) {
    // If we've seen this number before, each previous occurrence forms a new good pair
    if (freq.has(num)) {
      result += freq.get(num)!;
      freq.set(num, freq.get(num)! + 1);
    } else {
      freq.set(num, 1);
    }
  }

  return result;
}

var input = [1, 2, 3, 1, 1, 3];
var out = numIdenticalPairs(input);

console.log(out);

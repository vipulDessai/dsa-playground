export const url =
  '[Grumpy Bookstore Owner](https://leetcode.com/problems/grumpy-bookstore-owner/description/)';

function maxSatisfied(
  customers: number[],
  grumpy: number[],
  minutes: number,
): number {
  const n = customers.length;
  let l = 0,
    r = 0,
    max = 0;

  let s1 = 0;
  while (r < n) {
    if (grumpy[r] === 1) {
      s1 += customers[r];
    }

    if (r >= minutes) {
      if (grumpy[l] === 1) {
        s1 -= customers[l];
      }

      ++l;
    }

    max = Math.max(max, s1);

    ++r;
  }

  let s2 = 0;
  for (let i = 0; i < n; ++i) {
    if (grumpy[i] === 0) {
      s2 += customers[i];
    }
  }

  return s2 + max;
}

var input = [1, 0, 1, 2, 1, 1, 7, 5],
  g = [0, 1, 0, 1, 0, 1, 0, 1],
  m = 3;
var out = maxSatisfied(input, g, m);

console.log(out);

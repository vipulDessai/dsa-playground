export const url =
  '[Koko Eating Bananas](https://leetcode.com/problems/koko-eating-bananas)';

function minEatingSpeed(piles: number[], h: number): number {
  function feasible(capacity: number) {
    let i = 0,
      j = 0;
    while (i < h && j < piles.length) {
      i += Math.ceil(piles[j] / capacity);
      ++j;
    }

    if (i <= h && j == piles.length) {
      return true;
    }

    return false;
  }

  let l = 1;
  let r = Math.max(...piles);

  while (l < r) {
    const m = Math.floor(l + (r - l) / 2);

    if (feasible(m)) {
      r = m;
    } else {
      l = m + 1;
    }
  }

  // returning l or r both will work
  return r;
}

minEatingSpeed([3, 6, 7, 11], 8);

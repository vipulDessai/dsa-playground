export const url =
  '[Watering Plants II](https://leetcode.com/problems/watering-plants-ii/description/)';

// incomplete - so do the `TODO`
function minimumRefill(
  plants: number[],
  capacityA: number,
  capacityB: number,
): number {
  const n = plants.length;
  let l = 0,
    r = n - 1,
    res = 0,
    sumA = capacityA,
    sumB = capacityB;

  while (l < r) {
    if (sumA - plants[l] < 0) {
      ++res;
      sumA = capacityA;
    }

    sumA -= plants[l];
    ++l;

    if (sumB - plants[r] < 0) {
      ++res;
      sumB = capacityB;
    }

    sumB -= plants[r];
    --r;
  }

  // in case the array is of odd length
  if (l === r) {
    const curPlant = plants[l];
    const max = Math.max(sumA, sumB);
    if (max < curPlant) {
      ++res;
    }
  }

  return res;
}

var p = [2, 1, 1],
  cA = 2,
  cB = 2;
var out = minimumRefill(p, cA, cB);

console.log(out);

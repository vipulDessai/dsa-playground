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
    sumA = 0,
    sumB = 0;

  while (l <= r) {
    if (l === r) {
      const cur = plants[l];
      if (sumA - capacityA >= sumB - capacityB) {
        if (sumA + cur > capacityA) {
          ++res;
        }
      } else {
        if (sumB + cur > capacityB) {
          ++res;
        }
      }

      break;
    }

    sumA += plants[l];
    if (sumA > capacityA) {
      ++res;
      sumA = 0;
    } else {
      ++l;
    }

    if (l === r) {
      break;
    }

    sumB += plants[r];
    if (sumB > capacityB) {
      ++res;
      sumB = 0;
    } else {
      --r;
    }
  }

  return res;
}

var p = [2, 2, 3, 3],
  cA = 4,
  cB = 5;
var out = minimumRefill(p, cA, cB);

console.log(out);

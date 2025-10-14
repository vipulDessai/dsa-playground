// Do NOT use Math.floor(x ** 0.5);
// coz it beats 100% on leetcode 🤣
// instead use binary search
function mySqrt(x: number): number {
  let l = 0;
  let r = x;

  while (l < r) {
    const m = Math.floor(l + (r - l) / 2);

    // in this case we are looking for higher value (max value or upper bound)
    // i.e. even when we might have found an answer
    // we still look for a higher value
    if (m * m <= x) {
      l = m + 1;
    } else {
      r = m;
    }
  }

  // why l - 1? is because we do l = m + 1
  // i.e. l is most likely m but we still set m + 1
  // so at the end just a correction
  return l - 1;
}

mySqrt(8);

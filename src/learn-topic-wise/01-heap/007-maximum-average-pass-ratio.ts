export const url =
  '[maximum average pass ratio](https://leetcode.com/problems/maximum-average-pass-ratio/)';

function maxAverageRatio(classes: number[][], extraStudents: number): number {
  const n = classes.length;

  classes.sort((a, b) => {
    const avgA = a[0] / a[1];
    const avgB = b[0] / b[1];
    return avgA - avgB;
  });

  let res = 0;
  for (let i = 0; i < n; ++i) {
    let [pass, total] = classes[i];
    if (pass < total && extraStudents > 0) {
      const max = total - pass;

      if (max > extraStudents) {
        pass += extraStudents;
        total += extraStudents;
        extraStudents = 0;
      } else {
        pass += max;
        total += max;
        extraStudents -= max;
      }
    }

    res += pass / total;
  }

  return res / n;
}

var input = [
    [1, 2],
    [3, 5],
    [2, 2],
  ],
  e = 2;
var out = maxAverageRatio(input, e);

console.log(out);

export const url =
  '[Spiral Matrix III](https://leetcode.com/problems/spiral-matrix-iii/description/)';

function spiralMatrixIII(
  rows: number,
  cols: number,
  rStart: number,
  cStart: number,
): number[][] {
  const res: number[][] = [[rStart, cStart]],
    t = rows * cols,
    direction = [
      [0, 1],
      [1, 0],
      [0, -1],
      [-1, 0],
    ];

  let s = 1,
    d = 0,
    r = rStart,
    c = cStart;
  while (res.length < t) {
    for (let i = 0; i < 2; ++i) {
      for (let j = 0; j < s; ++j) {
        r += direction[d % 4][0];
        c += direction[d % 4][1];

        if (r < rows && r >= 0 && c < cols && c >= 0) {
          res.push([r, c]);
        }
      }
      ++d;
    }
    ++s;
  }

  return res;
}

var r = 3,
  c = 3,
  rS = 1,
  cS = 1;
var out = spiralMatrixIII(r, c, rS, cS);
console.log(out);

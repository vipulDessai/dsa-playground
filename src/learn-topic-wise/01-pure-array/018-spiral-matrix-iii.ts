export const url =
  '[Spiral Matrix III](https://leetcode.com/problems/spiral-matrix-iii/description/)';

function spiralMatrixIII(
  rows: number,
  cols: number,
  rStart: number,
  cStart: number,
): number[][] {
  const result: number[][] = [[rStart, cStart]];
  const total = rows * cols;

  // Directions: east, south, west, north
  const directions = [
    [0, 1],
    [1, 0],
    [0, -1],
    [-1, 0],
  ];
  let steps = 1;
  let dirIndex = 0;
  let r = rStart,
    c = cStart;

  while (result.length < total) {
    for (let i = 0; i < 2; i++) {
      // two directions before increasing steps
      const [dr, dc] = directions[dirIndex % 4];
      for (let j = 0; j < steps; j++) {
        r += dr;
        c += dc;
        if (r >= 0 && r < rows && c >= 0 && c < cols) {
          result.push([r, c]);
        }
      }
      dirIndex++;
    }
    steps++;
  }
  return result;
}

var r = 3,
  c = 3,
  rS = 1,
  cS = 1;
var out = spiralMatrixIII(r, c, rS, cS);
console.log(out);

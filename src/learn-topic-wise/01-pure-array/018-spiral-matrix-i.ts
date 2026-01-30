export const url =
  '[Spiral Matrix I](https://leetcode.com/problems/spiral-matrix/)';

function spiralOrder(matrix: number[][]): number[] {
  const rLen = matrix.length,
    cLen = matrix[0].length;

  let count = rLen * cLen;

  const res: number[] = [];

  let r = 0,
    c = 0,
    d = 1;
  const directions = [
    [-1, 0], // up
    [0, 1], // left
    [1, 0], // down
    [0, -1], // right
  ];

  while (count > 0) {
    res.push(matrix[r][c]);
    matrix[r][c] = Infinity;
    --count;

    if (count === 0) break;

    let nR = r + directions[d][0],
      nC = c + directions[d][1];
    while (
      nR < 0 ||
      nR >= rLen ||
      nC < 0 ||
      nC >= cLen ||
      (nR >= 0 &&
        nR < rLen &&
        nC >= 0 &&
        nC < cLen &&
        matrix[nR][nC] === Infinity)
    ) {
      ++d;

      nR = r + directions[d % 4][0];
      nC = c + directions[d % 4][1];
    }

    r += directions[d][0];
    c += directions[d][1];
  }

  return res;
}

var matrix = [
  [1, 2, 3, 4],
  [5, 6, 7, 8],
  [9, 10, 11, 12],
];
matrix = [
  [1, 2],
  [3, 4],
];
console.log(spiralOrder(matrix));

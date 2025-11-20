export const url =
  'https://leetcode.com/problems/reshape-the-matrix/description/';

function matrixReshape(mat: number[][], r: number, c: number): number[][] {
  const row = mat.length;
  const cols = mat[0].length;

  const res: number[][] = [];

  let k = 0,
    l = 0;
  for (let i = 0; i < r; ++i) {
    res.push([]);
    for (let j = 0; j < c; ++j) {
      if (k < row && l < cols && mat[k][l]) {
        res[i].push(mat[k][l]);

        ++l;
        if (l === cols) {
          ++k;
          l = 0;
        }
      } else {
        return mat;
      }
    }
  }

  return res;
}

var input = [
    [1, 2],
    [3, 4],
  ],
  r = 1,
  c = 4;

var input = [
    [2, 5],
    [8, 4],
    [0, -1],
  ],
  r = 6,
  c = 1;

var out = matrixReshape(input, r, c);

console.log(out);

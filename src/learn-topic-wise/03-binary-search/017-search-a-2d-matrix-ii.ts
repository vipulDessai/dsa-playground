export const url =
  '[Search a 2D Matrix II](https://leetcode.com/problems/search-a-2d-matrix-ii/description/)';

function searchMatrix(matrix: number[][], target: number): boolean {
  let rLen = matrix.length,
    cLen = matrix[0].length,
    r = 0,
    c = cLen - 1;

  while (r < rLen && c >= 0) {
    if (matrix[r][c] === target) {
      return true;
    } else if (matrix[r][c] > target) {
      --c;
    } else {
      ++r;
    }
  }

  return false;
}

var input = [
    [1, 4, 7, 11, 15],
    [2, 5, 8, 12, 19],
    [3, 6, 9, 16, 22],
    [10, 13, 14, 17, 24],
    [18, 21, 23, 26, 30],
  ],
  t = 5;
var out = searchMatrix(input, t);

console.log(out);

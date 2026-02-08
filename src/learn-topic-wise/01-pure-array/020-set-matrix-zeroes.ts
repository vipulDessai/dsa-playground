export const url =
  '[Set Matrix Zeroes](https://leetcode.com/problems/set-matrix-zeroes)';

function setZeroes(matrix: number[][]): void {
  const m = matrix.length,
    n = matrix[0].length;

  for (let i = 1; i < m; ++i) {
    for (let j = 1; j < n; ++j) {
      if (matrix[i][j] === 0) {
        // for O(1) space constraint use the first
        // element of row and col to store this info
        matrix[i][0] = 0;
        matrix[0][j] = 0;
      }
    }
  }

  for (let i = 1; i < m; ++i) {
    if (matrix[i][0] === 0) {
      for (let j = 1; j < n; ++j) {
        matrix[i][j] = 0;
      }
    }
  }

  for (let i = 0; i < n; ++i) {
    if (matrix[0][i] === 0) {
      for (let j = 1; j < m; ++j) {
        matrix[j][i] = 0;
      }
    }
  }

  if (matrix[0][0] === 0) {
    for (let i = 0; i < n; ++i) {
      matrix[0][i] = 0;
    }
  }
}

var input = [];
console.log(setZeroes(input));

export const url =
  '[Set Matrix Zeroes](https://leetcode.com/problems/set-matrix-zeroes)';

function setZeroes(matrix: number[][]): void {
  const m = matrix.length,
    n = matrix[0].length;

  let rZ = false,
    cZ = false;
  for (let i = 0; i < n; ++i) {
    if (matrix[0][i] === 0) {
      rZ = true;
      break;
    }
  }
  for (let i = 0; i < m; ++i) {
    if (matrix[i][0] === 0) {
      cZ = true;
      break;
    }
  }

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

  // fill cols
  for (let i = 1; i < m; ++i) {
    if (matrix[i][0] === 0) {
      for (let j = 1; j < n; ++j) {
        matrix[i][j] = 0;
      }
    }
  }
  // fill rows
  for (let i = 1; i < n; ++i) {
    if (matrix[0][i] === 0) {
      for (let j = 1; j < m; ++j) {
        matrix[j][i] = 0;
      }
    }
  }

  if (rZ) {
    for (let i = 0; i < n; ++i) {
      matrix[0][i] = 0;
    }
  }
  if (cZ) {
    for (let i = 0; i < m; ++i) {
      matrix[i][0] = 0;
    }
  }
}

var input = [
  [1, 2, 3, 4],
  [5, 0, 7, 8],
  [0, 10, 11, 12],
  [13, 14, 15, 0],
];
console.log(setZeroes(input));

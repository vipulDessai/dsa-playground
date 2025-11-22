export const url = 'https://leetcode.com/problems/toeplitz-matrix/description/';

// my solution
function isToeplitzMatrix(matrix: number[][]): boolean {
  const r = matrix.length,
    c = matrix[0].length;

  for (let i = 0; i < c; ++i) {
    let item = matrix[0][i];

    let j = 1,
      k = i + 1;
    while (j < r && k < c) {
      if (matrix[j][k] !== item) {
        return false;
      }

      ++j;
      ++k;
    }
  }

  for (let i = 1; i < r; ++i) {
    let item = matrix[i][0];

    let j = i + 1,
      k = 1;
    while (j < r && k < c) {
      if (matrix[j][k] !== item) {
        return false;
      }

      ++j;
      ++k;
    }
  }

  return true;
}

// var input = [
//   [1, 2, 3, 4],
//   [5, 1, 2, 3],
//   [9, 5, 1, 2],
// ];
// var out = isToeplitzMatrix(input);
// console.log(out);

function isToeplitzMatrixStream_partial_row_load(matrix: number[][]): boolean {
  if (matrix.length < 2) return true;

  let prevRow = matrix[0];

  for (let i = 1; i < matrix.length; ++i) {
    const curRow = matrix[i];
    for (let j = 1; j < matrix[0].length; ++j) {
      if (curRow[j] !== prevRow[j - 1]) {
        return false;
      }
    }

    prevRow = curRow;
  }

  return true;
}

var input = [
  [1, 2, 3, 4],
  [5, 1, 2, 3],
  [9, 5, 1, 2],
];
var out = isToeplitzMatrixStream_partial_row_load(input);
console.log(out);

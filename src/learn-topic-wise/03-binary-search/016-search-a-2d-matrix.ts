export const url =
  '[Search a 2D Matrix](https://leetcode.com/problems/search-a-2d-matrix/description/)';

function searchMatrix(matrix: number[][], target: number): boolean {
  const rows = matrix.length;
  const cols = matrix[0].length;

  let t = 0;
  let b = rows - 1;
  while (t <= b) {
    const m = Math.floor(t + (b - t) / 2);
    if (target > matrix[m][matrix[m].length - 1]) {
      t = m + 1;
    } else if (target < matrix[m][0]) {
      b = m - 1;
    } else {
      break;
    }
  }

  // if the while loop ended
  if (t > b) {
    return false;
  }

  const targetRow = (t + b - ((t + b) % 2)) / 2;
  let l = 0,
    r = cols - 1;
  while (l <= r) {
    const m = Math.floor(l + (r - l) / 2);
    const mVal = matrix[targetRow][m];
    if (target === mVal) return true;
    if (target > mVal) {
      l = m + 1;
    } else {
      r = m - 1;
    }
  }

  return false;
}

// var m = [
//     [1, 3, 5, 7],
//     [10, 11, 16, 20],
//     [23, 30, 34, 60],
//   ],
//   t = 3;
// var out = searchMatrix(m, t);

// console.log(out);

function searchMatrix_test(matrix: number[][], target: number): boolean {
  const rLen = matrix.length,
    cLen = matrix[0].length;

  let t = 0,
    b = rLen - 1;
  while (t <= b) {
    const m = Math.floor(t + (b - t) / 2);

    if (target > matrix[m][cLen - 1]) {
      t = m + 1;
    } else if (target < matrix[m][0]) {
      b = m - 1;
    } else {
      break;
    }
  }

  if (t > b) {
    return false;
  }

  // why it cant be current value of t or b
  // because in the above loop if the break logic was triggered
  // then the target in is the row m, and not in t or b
  const targetRow = matrix[Math.floor(t + (b - t) / 2)];
  let l = 0,
    r = cLen - 1;
  while (l <= r) {
    const m = Math.floor(l + (r - l) / 2);

    if (targetRow[m] > target) {
      l = m + 1;
    } else if (targetRow[m] < target) {
      r = m - 1;
    } else {
      return true;
    }
  }

  return false;
}

var m = [
    [1, 3, 5, 7],
    [10, 11, 16, 20],
    [23, 30, 34, 60],
  ],
  t = 13;
var out = searchMatrix_test(m, t);

console.log(out);

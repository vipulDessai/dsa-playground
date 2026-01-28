export const url =
  '[Spiral Matrix](https://leetcode.com/problems/spiral-matrix-ii/)';

function generateMatrix(n: number): number[][] {
  const matrix: number[][] = Array.from({ length: n }, () => Array(n).fill(0));

  let left = 0,
    right = n - 1;
  let top = 0,
    bottom = n - 1;
  let num = 1;

  while (left <= right && top <= bottom) {
    // left → right
    for (let j = left; j <= right; j++) {
      matrix[top][j] = num++;
    }
    top++;

    // top → bottom
    for (let i = top; i <= bottom; i++) {
      matrix[i][right] = num++;
    }
    right--;

    // right → left
    for (let j = right; j >= left; j--) {
      matrix[bottom][j] = num++;
    }
    bottom--;

    // bottom → top
    for (let i = bottom; i >= top; i--) {
      matrix[i][left] = num++;
    }
    left++;
  }

  return matrix;
}

var input = 3;
var out = generateMatrix(input);
console.log(out);

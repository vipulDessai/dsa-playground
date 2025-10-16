export const url =
  '[Duplicate Zeros](https://leetcode.com/problems/duplicate-zeros/description/)';

// my brute force solution
function duplicateZeros(arr: number[]): void {
  const n = arr.length,
    q: number[] = [];

  for (let i = 0; i < n; ++i) {
    if (arr[i] === 0) {
      q.push(0);
    }

    if (q.length > 0) {
      q.push(arr[i]);

      // but shift() makes the time complexity O(n^2)
      arr[i] = q.shift()!;
    }
  }
}

var input = [1, 0, 0, 2, 3, 0, 0, 4];
duplicateZeros(input);

function duplicateZeros_pure_2_pointers(arr: number[]): void {
  let n = arr.length;
  let zeros = 0;

  // Count zeros that would be duplicated
  for (let i = 0; i < n; i++) {
    if (arr[i] === 0) zeros++;
  }

  let i = n - 1;
  let j = i + zeros; // this is like simulating extra space

  // Traverse backwards
  while (i < j) {
    if (j < n) {
      arr[j] = arr[i];
    }

    if (arr[i] === 0) {
      j--;
      if (j < n) {
        arr[j] = 0;
      }
    }

    i--;
    j--;
  }
}

var input = [1, 0, 0, 2, 3, 0, 0, 4];
duplicateZeros_pure_2_pointers(input);

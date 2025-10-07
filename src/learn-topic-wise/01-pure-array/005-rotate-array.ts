export const url =
  '[Rotate Array](https://leetcode.com/problems/rotate-array/description/)';

console.log('revers with mod');

/**
 Do not return anything, modify nums in-place instead.
 */
function reverse(l: number, r: number, nums: number[]) {
  while (l < r) {
    [nums[l], nums[r]] = [nums[r], nums[l]];

    ++l;
    --r;
  }
}

function rotate(nums: number[], k: number): void {
  const n = nums.length;

  reverse(0, n - 1, nums);
  reverse(0, (k % n) - 1, nums);
  reverse(k % n, n - 1, nums);
}

var input = [1, 2, 3, 4, 5, 6, 7],
  k = 3;
rotate(input, k);

console.log('Cyclic replacement');

// Solution - Cyclic replacement
function rotate_cyclic_replacement(nums: number[], k: number): void {
  const n = nums.length;
  k = k % n;
  if (k === 0 || n <= 1) return;

  let count = 0,
    i = 0;

  while (count < n) {
    let curI = i;
    let prev = nums[i];

    do {
      const next = (curI + k) % n;
      [nums[next], prev] = [prev, nums[next]];

      curI = next;
      count++;
    } while (curI !== i);

    i++;
  }
}

var input = [1, 2, 3, 4, 5, 6, 7],
  k = 3;
rotate_cyclic_replacement(input, k);

console.log('foo');

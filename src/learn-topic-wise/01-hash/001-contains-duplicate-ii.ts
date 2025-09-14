export const url = 'https://leetcode.com/problems/contains-duplicate-ii/';

function containsNearbyDuplicate(nums: number[], k: number): boolean {
  const n = nums.length;

  const uSet = new Set();
  for (let i = 0; i < n; ++i) {
    if (i > k) {
      uSet.delete(nums[i - k - 1]);
    }

    const cur = nums[i];
    if (uSet.has(cur)) {
      return true;
    }

    uSet.add(cur);
  }

  return false;
}

var input = [1, 2, 3, 1],
  k = 3;
var out = containsNearbyDuplicate(input, k);

console.log(out);

function containsNearbyDuplicate_sliding_window(
  nums: number[],
  k: number,
): boolean {
  const uSet = new Set(),
    n = nums.length;

  let l = 0,
    r = 0;
  while (r <= k && r < n) {
    const cur = nums[r];
    if (uSet.has(cur)) {
      return true;
    }

    uSet.add(cur);
    ++r;
  }

  while (r < n) {
    // delete should be first, otherwise
    // the fixed sized window is not preserved correctly
    uSet.delete(nums[l]);

    if (uSet.has(nums[r])) {
      return true;
    }

    uSet.add(nums[r]);

    ++l;
    ++r;
  }

  return false;
}

var input = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
  k = 15;
var out = containsNearbyDuplicate_sliding_window(input, k);

console.log(out);

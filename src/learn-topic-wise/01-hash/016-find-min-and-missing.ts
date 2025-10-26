export const url = 'https://leetcode.com/problems/set-mismatch/description';

function findErrorNums_hash(nums: number[]): number[] {
  const n = nums.length;
  const countMap = Array(n).fill(0);

  for (let i = 0; i < n; ++i) {
    const cur = nums[i];
    countMap[cur - 1]++;
  }

  let dup = 0,
    miss = 0;
  for (let i = 0; i < n; ++i) {
    // missing
    if (countMap[i] === 0) {
      miss = i + 1;
    }

    // duplicate
    if (countMap[i] === 2) {
      dup = i + 1;
    }
  }

  return [dup, miss];
}

var input = [1, 2, 2, 4];
var out = findErrorNums_hash(input);
console.log(out);

function findErrorNums_sumset_formula(nums: number[]): number[] {
  const n = nums.length;
  const expectedSum = (n * (n + 1)) / 2;
  const s = new Set<number>();

  let actualSum = 0;
  for (const num of nums) {
    actualSum += num;
    s.add(num);
  }

  // sum of all nums item without the duplicate
  let uniqueSum = 0;
  for (const item of s) {
    uniqueSum += item;
  }

  // duplicate, missing
  return [actualSum - uniqueSum, expectedSum - uniqueSum];
}

var input = [1, 2, 2, 4];
var out = findErrorNums_sumset_formula(input);
console.log(out);

function findErrorNums_xor_hashset(nums: number[]): number[] {
  const n = nums.length;

  const count = Array(n).fill(0);

  let xorSum = 0,
    dup = 0;
  for (let i = 0; i < n; i++) {
    var current = nums[i];

    // XOR expected vs actual
    xorSum ^= (i + 1) ^ current;

    count[current - 1]++;

    if (count[current - 1] == 2) {
      dup = current;
    }
  }

  // this is kinda same as expectedSum - uniqueSum
  xorSum ^= dup;

  // duplicate, missing
  return [dup, xorSum];
}

var input = [1, 2, 2, 4];
var out = findErrorNums_xor_hashset(input);
console.log(out);

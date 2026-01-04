export const url =
  '[Check If N and Its Double Exist](https://leetcode.com/problems/check-if-n-and-its-double-exist/)';

function checkIfExist(arr: number[]): boolean {
  const uSet = new Set<number>();

  for (let i = 0; i < arr.length; ++i) {
    const cur = arr[i];
    if (
      uSet.has(cur * 2) ||
      // why ?
      // we dont have to check odd numbers coz the input arr does not have floats
      // Removing it won’t break correctness, but it will add redundant lookups
      (cur % 2 === 0 && uSet.has(cur / 2))
    ) {
      return true;
    }

    uSet.add(cur);
  }

  return false;
}

var input = [];
var out = checkIfExist(input);

console.log(out);
